using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.BL.Api
{
    public interface IAirportMediator
    {
        void PlaneArrive(IPlane plane);
    }
}
