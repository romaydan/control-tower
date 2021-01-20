using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.Common.Models.DTOs
{
    public class PlaneDTO
    {
        public string FlightNumber { get; set; }
        public string PlaneType { get; set; }
        public int AdditionalInfo { get; set; }
        public string Model { get; set; }
        public PlaneDTO(IPlane plane)
        {
            FlightNumber = plane.FlightNumber;
            PlaneType = plane.GetType().Name;
            Model = plane.Model;
            if (plane is IPassenger)
            {
                var passPlane = plane as IPassenger;
                AdditionalInfo = passPlane.Passengers;
            }
            else if (plane is ICargo)
            {
                var cargoPlane = plane as ICargo;
                AdditionalInfo = cargoPlane.CargoWeightInTons;
            }

        }
        public static IList<PlaneDTO> CollectionToDTOs(IEnumerable<IPlane> planes)
        {
            List<PlaneDTO> planesDTO = new List<PlaneDTO>();
            foreach (var plane in planes)
            {
                planesDTO.Add(new PlaneDTO(plane));
            }
            return planesDTO;
        }
    }
}
