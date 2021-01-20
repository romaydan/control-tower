using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.Common.Models.Api
{
   public interface ITakeoff
    {
        public Action<IPlane> Takeoff { get; set; }
    }
}
