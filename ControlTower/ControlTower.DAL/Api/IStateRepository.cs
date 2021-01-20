using ControlTower.Common.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.DAL.Api
{
  public   interface IStateRepository
    {
        bool SetFacilitiesState(IList<FacilityDTO> facility);
        IList<FacilityDTO> GetFacilitiesState();
    }
}
