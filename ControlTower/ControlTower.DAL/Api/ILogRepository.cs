using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Logs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.DAL.Api
{
    public interface ILogRepository
    {
        bool WriteLogToDb(Log log);
        IEnumerable<Log> GetLogs();
    }
}
