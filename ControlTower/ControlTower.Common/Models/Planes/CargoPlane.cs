using ControlTower.Common.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.Common.Models.Planes
{
    public class CargoPlane : PlaneBase, ICargo
    {
        public int CargoWeightInTons { get; set; }

        public CargoPlane()
        {
            IsLoaded = true;
            HasMaintained = false;
            CargoWeightInTons = PlaneFactory.GetRandomNumber(40, 250);
        }
    }
}
