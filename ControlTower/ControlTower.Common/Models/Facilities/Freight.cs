using ControlTower.Common.Models.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ControlTower.Common.Models.Facilities
{
    public class Freight : FacilityBase
    {
        public Freight() :base()
        {
            TaskTime = new TimeSpan(0, 0, 0,1,500);
            PrevTypes.Add(typeof(LandingStrip));
        }

        protected override void SpecialOperation(IPlane plane)
        {
            Thread.Sleep(TaskTime);
            plane.IsLoaded = false;
            SendMessage?.Invoke($"{plane.FlightNumber} has been unloaded ");
            Thread.Sleep(TaskTime);
            plane.IsLoaded = true;
            SendMessage?.Invoke($"{plane.FlightNumber} has been loaded ");
        }
    }
}
