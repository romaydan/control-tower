using ControlTower.Common.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.BL.Api
{
    public interface IAirportState
    {
        void SetContext(IList<IFacility> state);
        bool GetState();
        bool SetState(IFacility facility);
    }
}
