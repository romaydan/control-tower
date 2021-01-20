using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ControlTower.Common.Models.Facilities
{
    public class RefuelAndCleaning : FacilityBase
    {
        public RefuelAndCleaning()
        {
            TaskTime = new TimeSpan(0, 0,3);
            PrevTypes.Add(typeof(Freight));
            PrevTypes.Add(typeof(Terminal));
        }
        protected override void SpecialOperation(IPlane plane)
        {
            Thread.Sleep(TaskTime);
            plane.HasMaintained = true;
            SendMessage?.Invoke($"{plane.FlightNumber} has been Refueled And Cleaned");
        }
    }
}
