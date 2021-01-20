using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Facilities;
using ControlTower.Common.Models.Planes;
using System;
using Xunit;

namespace ControlTower.Tests
{
    public class AirportShould
    {
        [Fact]
        public void PlaneCantArriveIfFacilityIsNotEmpty()
        {
            IFacility facility = new Freight();
            IPlane existingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            IPlane testPlane = PlaneFactory.CreatePlane<CargoPlane>();
            facility.Plane = existingPlane;
            facility.PlaneArrival(testPlane);
            Assert.Equal<IPlane>(existingPlane, facility.Plane);
        }
        [Fact]
        public void PlaneArriveIfFacilityIsEmpty()
        {
            IFacility testedFacility = new Freight();
            IFacility nextFacility = new RefuelAndCleaning();
            IPlane existingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            IPlane arrivingPlane = PlaneFactory.CreatePlane<PassengerPlane>();
            nextFacility.Plane = existingPlane;
            testedFacility.NextFacilities.Add(nextFacility as FacilityBase);
            testedFacility.PlaneArrival(arrivingPlane);

            Assert.Equal<IPlane>(arrivingPlane, testedFacility.Plane);

        }
        //[Fact]
        //public void PlaneNotRedirectIfNextFacilitiesAreFull()
        //{
        //    IFacility testedFacility = new Freight();
        //    IFacility nextFacility = new RefuelAndCleaning();
        //    IPlane existingPlane = PlaneFactory.CreatePlane<CargoPlane>("Boeing Dreamlifter");
        //    IPlane arrivingPlane = PlaneFactory.CreatePlane<PassengerPlane>("Boeing 787 Dreamliner")
        //}
        [Fact]
        public void FacilityTurnsEmptyAfterPlaneIsReadyToMoveToNextFacility()
        {
            IFacility testedFacility = new Freight();
            IFacility nextFacility = new RefuelAndCleaning();
            IFacility nextNextFacility = new TakeoffStrip();
            IPlane existingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            IPlane arrivingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            nextNextFacility.Plane = existingPlane;
            testedFacility.NextFacilities.Add(nextFacility as FacilityBase);
            nextFacility.NextFacilities.Add(nextFacility as FacilityBase);
            testedFacility.PlaneArrival(arrivingPlane);
            Assert.Null(testedFacility.Plane);
        }
        [Fact]
        public void FacilityWithoutNextFacilitiesEmptiesAfterDoneWithPlane()
        {
            IFacility testedFacility = new TakeoffStrip();
            IPlane existingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            testedFacility.PlaneArrival(existingPlane);
            Assert.Null(testedFacility.Plane);

        }
        [Fact]
        public void FacilityMovesPlaneToNextFacilityWhoHasPlaneOnlyWhenTheFacilityEmpties()
        {
            IFacility testedFacility = new Freight();
            IFacility nextFacility = new RefuelAndCleaning();
            IFacility nextNextFacility = new TakeoffStrip();
            IFacility nextNextNextFacility = new TakeoffStrip();
            IPlane existingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            IPlane arrivingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            testedFacility.NextFacilities.Add(nextFacility as FacilityBase);
            nextFacility.NextFacilities.Add(nextNextFacility as FacilityBase);
            nextNextFacility.NextFacilities.Add(nextNextNextFacility as FacilityBase);
            nextNextNextFacility.Plane = existingPlane;
            nextFacility.PlaneArrival(existingPlane);
            testedFacility.PlaneArrival(arrivingPlane);
            Assert.Equal<IPlane>(arrivingPlane,nextFacility.Plane);
        }
        [Fact]
        public void IfFacilityNextFacilitiesNotEmptyPlaneWillStay()
        {
            IFacility testedFacility = new Freight();
            IFacility nextFacility = new RefuelAndCleaning();
            IPlane existingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            IPlane arrivingPlane = PlaneFactory.CreatePlane<CargoPlane>();
            testedFacility.NextFacilities.Add(nextFacility as FacilityBase);
            nextFacility.Plane = existingPlane;
            testedFacility.PlaneArrival(existingPlane);
            Assert.Equal<IPlane>(existingPlane, nextFacility.Plane);

        }
        //[Fact]
        //public void PlaneArriveIfFacilityIsEmptys()
        //{

        //}
        //[Fact]
        //public void PlaneArriveIfFacilityIsEmptys()
        //{

        //}
        //[Fact]
        //public void PlaneArriveIfFacilityIsEmptys()
        //{

        //}
        //[Fact]
        //public void PlaneArriveIfFacilityIsEmptys()
        //{

        //}
        //[Fact]
        //public void PlaneArriveIfFacilityIsEmptys()
        //{

        //}
    }
}
