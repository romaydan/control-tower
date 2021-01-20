using ControlTower.Common.Models.Facilities;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControlTower.Common.Models.Api
{
    public interface IFacility
    {
        public int Id { get; set; }
        public IPlane Plane { get; set; }
        public bool IsEmpty { get => Plane == null; }
        public IList<Type> PrevTypes { get; set; }
        public IList<IFacility> NextFacilities { get; set; }
       
        public Action<IFacility> SaveState { get; set; }
        public Action<string> SendMessage { get; set; }
        public Action<IFacility, IFacility, IPlane> SaveHistory { get; set; }

        event EventHandler FacilityIsEmpty;

        public void PlaneArrival(IPlane plane);


    }
}

