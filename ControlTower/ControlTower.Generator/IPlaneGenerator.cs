using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.Generator
{
    public interface IPlaneGenerator
    {
         Task CreatePlane<T>() where T : IPlane, new();
        void ToggleAutoPlanes(bool data,int interval);
    }
}
