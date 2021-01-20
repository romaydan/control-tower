using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Facilities;
using ControlTower.Common.Models.Planes;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var plane = PlaneFactory.CreatePlane<PassengerPlane>( "boeing 747");     
            //var landingStrip = FacilityFactory.CreateFacility<LandingStrip>();
            //landingStrip.PlaneArrival(plane);
            Console.ReadKey();
        }

        private static void onPlaneArrival(IPlane plane)
        {
            throw new NotImplementedException();
        }
    }
}
