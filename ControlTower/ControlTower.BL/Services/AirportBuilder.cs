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
    public class AirportBuilder : IAirportBuilder
    {
        IList<IFacility> airportFacilities;
        IList<IFacility> facilities;
        private int coutner = 1;
        private readonly IAirportState state;
        private readonly ISystemSnapshot snapshot;
        private readonly ILogService logService;
        private readonly INotificationService notification;

        public AirportBuilder(IAirportState state, INotificationService notification, ISystemSnapshot snapshot, ILogService logService)
        {
            airportFacilities = new List<IFacility>();
            facilities = new List<IFacility>();
            this.state = state;
            this.snapshot = snapshot;
            this.logService = logService;
            this.notification = notification;
        }

        public IAirportBuilder AddFacility<T>() where T : FacilityBase, new()
        {
            var facility = CreateFacility<T>();
            facilities.Add(facility);

            return this;
        }

        public IList<IFacility> BuildAirport()
        {
            foreach (var facility in facilities)
            {
                AssignNextAndILandable(facility);
                airportFacilities.Add(facility);
            }
            return airportFacilities;
        }

        private void AssignNextAndILandable(IFacility facility)
        {
            if (facility.PrevTypes == null && facility is ILandable)
            {
                var ls = facility as ILandable;
                ls.PlaneLanded = (plane) =>
                {
                    Task.Run(() =>
                    {
                        snapshot.UpdatePlane(plane);
                        notification.UpdateBoard();
                    });
                };
            }
            else
            {
                foreach (var type in facility.PrevTypes)
                {
                    var prevList = filterList(type);
                    AddNextFacilities(prevList, facility);
                }
            }
        }

        private IList<IFacility> filterList(Type type)
        {
            var list = new List<IFacility>();
            foreach (var fas in facilities)
            {
                if (fas.GetType() == type)
                    list.Add(fas);
            }
            return list;
        }

        private void AddNextFacilities(IList<IFacility> facilities, IFacility facility)
        {
            foreach (var fas in facilities)
            {
                fas.NextFacilities.Add(facility);
            }
        }

        private IFacility CreateFacility<T>() where T : FacilityBase, new()
        {
            return new T
            {
                Id = coutner++,
                SaveState = (facility) =>
                Task.Run(() => state.SetState(facility)),
                SendMessage = (message) => Task.Run(() => notification.SendMessage(message)),
                SaveHistory = (oFacility, dFacility, plane) => Task.Run(() => logService.WriteLogMessage(oFacility, dFacility, plane))
            };
        }


    }
}