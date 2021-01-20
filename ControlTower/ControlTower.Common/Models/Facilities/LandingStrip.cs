using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlTower.Common.Models.Facilities
{
    public class LandingStrip : FacilityBase, ILandable
    {
        public Action<IPlane> PlaneLanded { get; set; }

        public LandingStrip()
        {
            TaskTime = new TimeSpan(0, 0, 3);
            PrevTypes = null;
        }
        protected override void Redirect(IPlane plane, IList<IFacility> facilities)
        {
            IEnumerable<IFacility> specificFacilities = facilities;
            if (plane is CargoPlane)
                specificFacilities = facilities.OfType<Freight>();
            if (plane is PassengerPlane)
            {
                specificFacilities = facilities.OfType<Terminal>();
            }
            base.Redirect(plane, specificFacilities.ToList());
        }

        protected override void SpecialOperation(IPlane plane)
        {
            Thread.Sleep(TaskTime);
            plane.HasLanded = true;
            SendMessage.Invoke($"{plane.FlightNumber} has landed successfully");
            PlaneLanded?.Invoke(plane);
        }

    }
}
