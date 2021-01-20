using ControlTower.BL.Api;
using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Logs;
using ControlTower.Common.Models.Planes;
using ControlTower.DAL.Api;
using ControlTower.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.BL.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository repository;

        public LogService(ILogRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Log> GetLogs()
        {
            return repository.GetLogs();
        }
        public bool WriteLogMessage(IFacility originFacility, IFacility destinationFacility, IPlane plane)
        {
            var log = new Log
            {
                OriginFacilityId = originFacility.Id,
                DestinationFacilityId = destinationFacility.Id,
                Plane = plane as PlaneBase,
                OccurrenceDate = DateTime.Now
            };
            return repository.WriteLogToDb(log);
        }
    }
}
