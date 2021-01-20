using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.DTOs;
using ControlTower.Common.Models.Facilities;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.DAL.Api
{
    public interface ILandingsRepository
    {
        bool AddPlaneToLandings(IPlane plane);
        bool UpdatePlane(IPlane plane);
        IEnumerable<IPlane> GetLandings();
 
    }
}
