using ControlTower.BL.Api;
using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ControlTower.Generator
{
    public class PlaneGenerator : IPlaneGenerator
    {
        IAirportMediator airportService;
        Timer timer;
        int counter = 0;


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (counter++ % 2 == 0)
                CreatePlane<PassengerPlane>();
            else
                CreatePlane<CargoPlane>();
        }

        public PlaneGenerator(IAirportMediator airportService)
        {
            this.airportService = airportService;
            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
        }

        public Task CreatePlane<T>() where T : IPlane, new()
        {
            return Task.Run(() =>
             {
                 var plane = PlaneFactory.CreatePlane<T>();
                 airportService.PlaneArrive(plane);
             });

        }

        public void ToggleAutoPlanes(bool data, int interval)
        {
            if (data)
            {
                timer.Interval = interval*1000;
                timer.Start();
            }
            else
                timer.Stop();
        }
    }
}
