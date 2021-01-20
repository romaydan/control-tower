using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.Common.Models.Api
{
    public interface ILandable
    {
        public Action<IPlane> PlaneLanded { get; set; }
    }
}
