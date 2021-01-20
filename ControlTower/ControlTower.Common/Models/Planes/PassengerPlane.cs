using ControlTower.Common.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.Common.Models.Planes
{
   public class PassengerPlane : PlaneBase,IPassenger
    {
        public int Passengers { get; set ; }

        public PassengerPlane()
        {
            IsLoaded = true;
            HasMaintained = false;
            Passengers = PlaneFactory.GetRandomNumber(40, 250);
        }
    }
}
