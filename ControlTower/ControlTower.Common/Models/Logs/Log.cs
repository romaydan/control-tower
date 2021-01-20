using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControlTower.Common.Models.Logs
{
    public class Log
    {
        public int Id { get; set; }
        public PlaneBase Plane { get; set; }
        public int OriginFacilityId { get; set; }
        public int DestinationFacilityId { get; set; }
        public DateTime OccurrenceDate { get; set; }
    }
}
