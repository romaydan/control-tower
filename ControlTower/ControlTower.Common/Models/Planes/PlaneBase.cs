using ControlTower.Common.Models.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControlTower.Common.Models.Planes
{
    public abstract class PlaneBase : IPlane
    {
        [Key]
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Model { get; set; }
        public bool HasLanded { get; set; }
        public bool IsLoaded { get; set; }
        public bool HasMaintained { get; set; }
        public bool Departured { get; set; }
    }
}
