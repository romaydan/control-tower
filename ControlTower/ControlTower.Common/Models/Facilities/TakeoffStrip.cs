using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ControlTower.Common.Models.Facilities
{
    public class TakeoffStrip : FacilityBase, ITakeoff
    {
        public Action<IPlane> Takeoff { get ; set; }

        public TakeoffStrip()
        {
            TaskTime = new TimeSpan(0, 0, 5);
            PrevTypes.Add(typeof(RefuelAndCleaning));
        }

        protected override void SpecialOperation(IPlane plane)
        {
            Thread.Sleep(TaskTime);
            SendMessage?.Invoke($"{plane.FlightNumber} took off succesfully");
        }

        public override void PlaneArrival(IPlane plane)
        {
            base.PlaneArrival(plane);
            Takeoff?.Invoke(plane);
        }
    }
}
