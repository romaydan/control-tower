using ControlTower.BL.Api;
using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Facilities;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.BL.Services
{
    public class AirportMediator : IAirportMediator
    {
        private readonly ISystemSnapshot snapshot;
        private readonly IAirportBuilder builder;
        private readonly IAirportState state;
        private readonly INotificationService notificationService;
        IList<IFacility> facilities;
        Queue<IPlane> waitingList;
        object locker;
        public AirportMediator(ISystemSnapshot snapshot, IAirportBuilder builder, IAirportState state, INotificationService notificationService)
        {
            this.snapshot = snapshot;
            this.builder = builder;
            this.state = state;
            this.notificationService = notificationService;
            waitingList = new Queue<IPlane>();
            locker = new object();
            CreateFacilities();
            SendLandingsToTakeoffs();
        }

        public void PlaneArrive(IPlane plane)
        {
            var fullFacilities = new List<IFacility>();
            var landableFacilities = GetLandableFacilities();
          Task.Run(()=>snapshot.AddPlane(plane));
            waitingList.Enqueue(plane);
            foreach (var landable in landableFacilities)
            {
                if (landable.IsEmpty)
                {
                    landable.PlaneArrival(waitingList.Dequeue());
                    return;
                }
                else
                {
                    fullFacilities.Add(landable);
                }
            }
            foreach (var fullLandable in fullFacilities)
            {
                fullLandable.FacilityIsEmpty += WaitUntilFacilityHandler;
            }
        }

        private void SendLandingsToTakeoffs()
        {
            foreach (var plane in snapshot.GetLandings())
            {
                Task.Run(() => PlaneArrive(plane));
            }
        }

        private void CreateFacilities()
        {
            facilities = builder.AddFacility<LandingStrip>().AddFacility<LandingStrip>()
                .AddFacility<Freight>().AddFacility<Terminal>()
                .AddFacility<RefuelAndCleaning>().AddFacility<TakeoffStrip>().AddFacility<TakeoffStrip>().BuildAirport().ToList();
            state.SetContext(facilities);
            state.GetState();
            registerEventsEvent();

        }

        private void registerEventsEvent()
        {
            foreach (var landable in GetLandableFacilities())
            {
                landable.FacilityIsEmpty += WaitUntilFacilityHandler;
            }
            foreach (var takeoff in facilities.OfType<ITakeoff>())
            {
                takeoff.Takeoff += PlaneTakeoff;
            }
        }

        private IEnumerable<IFacility> GetLandableFacilities()
        {
            List<IFacility> landables = new List<IFacility>();
            foreach (var facility in facilities)
            {
                if (facility is ILandable)
                    landables.Add(facility);
            }
            return landables;
        }

        private void PlaneTakeoff(IPlane plane)
        {

            if (plane.HasLanded && plane.IsLoaded && plane.HasMaintained)
            {
                notificationService.SendMessage($"plane {plane.FlightNumber} has left the airport ");
                plane.Departured = true;
                snapshot.UpdatePlane(plane);
                notificationService.UpdateBoard();
            }
        }

        private void WaitUntilFacilityHandler(object sender, EventArgs e)
        {
            lock (locker)
            {
                if (sender != null && sender is IFacility)
                {
                    if (waitingList.Count > 0)
                    {
                        var plane = waitingList.Dequeue();
                        IFacility fas = sender as IFacility;
                        IFacility facility = facilities.FirstOrDefault(ef => fas.Id == ef.Id);
                        if (facility.IsEmpty)
                        {
                       Task.Run(()=>facility.PlaneArrival(plane));
                        }
                    }
                }
            }
        }



    }
}
