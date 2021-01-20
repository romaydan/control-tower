using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.BL.Api
{
    public interface ISystemSnapshot 
    {
        void AddPlane(IPlane plane);
        void UpdatePlane(IPlane plane);
        IList<IPlane> GetTakeoffs();
        IList<IPlane> GetLandings();
    }
}
