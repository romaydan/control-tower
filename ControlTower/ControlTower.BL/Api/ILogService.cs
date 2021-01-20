using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Logs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.BL.Api
{
    public interface ILogService
    {
       bool WriteLogMessage(IFacility originFacility, IFacility destinationFacility, IPlane plane);
        IEnumerable<Log> GetLogs();
    }
}
