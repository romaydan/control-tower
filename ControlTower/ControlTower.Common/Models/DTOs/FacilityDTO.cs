using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Facilities;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControlTower.Common.Models.DTOs
{
    public class FacilityDTO
    {
        [Key]
        public int FacilityId { get; set; }
        public string TypeName { get; set; }
        public PlaneBase Plane { get; set; }

        public void MapDto(IFacility facility)
        {
            Plane = facility.Plane as PlaneBase;
            FacilityId = facility.Id;
            TypeName = facility.GetType().Name;
        }
    }
}
