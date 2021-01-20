using ControlTower.BL.Api;
using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.DTOs;
using ControlTower.Common.Models.Facilities;
using ControlTower.DAL.Api;
using ControlTower.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlTower.BL.Services
{
    public class AirportState : IAirportState
    {
        private List<IFacility> currentState;
        private readonly IStateRepository repo;
        private readonly INotificationService notification;

        public AirportState(IStateRepository repo, INotificationService notification)
        {
            this.repo = repo;
            this.notification = notification;
        }
        public void SetContext(IList<IFacility> state)
        {
            currentState = state.ToList();
        }

        public bool GetState()
        {
            try
            {
                var facilities = repo.GetFacilitiesState();
                foreach (var facilitySnapshot in facilities)
                {
                    if (facilitySnapshot.Plane != null)
                        AssignFacilityState(facilitySnapshot);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SetState(IFacility facility)
        {
            var state = new List<FacilityDTO>();
            foreach (var fa in currentState)
            {
                state.Add(ExtractFacilityState(fa as IFacility));
            }
            notification.UpdateAirportState(state);
            return repo.SetFacilitiesState(state);
        }



        private FacilityDTO ExtractFacilityState(IFacility faciliy)
        {
            var fas = new FacilityDTO();
            fas.MapDto(faciliy);
            return fas;

        }
        private void AssignFacilityState(FacilityDTO facilitySnapshot)
        {
            var facility = currentState.FirstOrDefault(f => f.Id == facilitySnapshot.FacilityId);
            if (facility != null && facilitySnapshot.Plane != null)
            {
                Task.Run(() => facility.PlaneArrival(facilitySnapshot.Plane));
            }

        }
    }
}
