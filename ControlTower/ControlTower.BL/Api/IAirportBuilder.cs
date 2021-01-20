using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Facilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.BL.Api
{
   public interface IAirportBuilder 
    {
        IAirportBuilder AddFacility<T>()where T:FacilityBase,new();
        IList<IFacility> BuildAirport();
    }
}
