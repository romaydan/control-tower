using ControlTower.BL.Api;
using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.DTOs;
using ControlTower.DAL.Api;
using System.Collections.Generic;
using System.Linq;

namespace ControlTower.BL.Services
{
    public class SystemSnapshot : ISystemSnapshot
    {
        private readonly ILandingsRepository repository;
        private readonly INotificationService notificationService;

        public SystemSnapshot(ILandingsRepository repository, INotificationService notificationService)
        {
            this.repository = repository;
            this.notificationService = notificationService;
        }

        public void AddPlane(IPlane plane)
        {
            repository.AddPlaneToLandings(plane);
            notificationService.UpdateBoard();
        }
        public IList<IPlane> GetTakeoffs()
        {
            
            return repository.GetLandings().Where(plane => plane.HasLanded == true).ToList();
        }

        public IList<IPlane> GetLandings()
        {
            return  repository.GetLandings().Where(plane => plane.HasLanded == false).ToList();
        }

        public void UpdatePlane(IPlane plane)
        {
            repository.UpdatePlane(plane);
        }
    }
}
