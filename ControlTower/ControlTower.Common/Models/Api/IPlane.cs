using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControlTower.Common.Models.Api
{
    public interface IPlane
    {
        public string FlightNumber { get; set; }
        public string Model { get; set; }
        public bool HasLanded { get; set; }
        public bool IsLoaded { get; set; }
        public bool HasMaintained { get; set; }
        public bool Departured { get; set; }
    }
}
