using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlTower.Common.Models.Facilities
{
    public class Terminal : FacilityBase
    {
        public Terminal()
        {
            TaskTime = new TimeSpan(0, 0, 0,1,500);
            PrevTypes.Add(typeof(LandingStrip));
        }
        protected override  void SpecialOperation(IPlane plane)
        {
            Thread.Sleep(TaskTime);
            plane.IsLoaded = false;
            SendMessage?.Invoke($"{plane.FlightNumber} has been  unloaded");
            Thread.Sleep(TaskTime);
            plane.IsLoaded = true;
            SendMessage?.Invoke($"{plane.FlightNumber} has been loaded");
        }
    }
}
