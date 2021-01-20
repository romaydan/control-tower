using ControlTower.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlTower.Server.Controllers
{
    public class LogsController :Controller
    {
        private readonly LogService logService;

        public LogsController(LogService logService)
        {
            this.logService = logService;
        }
        [HttpGet]
        public ActionResult Logs()
        {
            var logs = logService.GetLogs();
            if (logs != null)
            {
                return Ok(logs);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
