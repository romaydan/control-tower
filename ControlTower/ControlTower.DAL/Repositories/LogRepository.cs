using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Logs;
using ControlTower.DAL.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.DAL.Repositories
{
    public class LogRepository : ILogRepository
    {
        public IEnumerable<Log> GetLogs()
        {

            using (var context = new AirportContext())
            {
                return context.Logs;
            }
        }
        public bool WriteLogToDb(Log log)
        {

                using (var context = new AirportContext())
                {
                    log.Plane = context.Planes.FirstOrDefault(plane => plane.Id == log.Plane.Id);
                    context.Logs.Add(log);
                    context.SaveChanges();
                    return true;
                }
            


        }
    }
}
