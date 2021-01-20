using ControlTower.Common.Models.Planes;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlTower.Hubs.Hubs
{
    public class AirportHub :Hub
    {
        //private readonly IAirportService airportService;
        //private readonly IPlaneGenerator generator;
        public AirportHub(/*IAirportService airportService,IPlaneGenerator generator*/)
        {
            //this.airportService = airportService;
            //this.generator = generator;
        }
        public async void CreatePlane()
        {
            //generator.CreatePlane<PassengerPlane>();
        }
    }
}
