using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.Planes;
using ControlTower.DAL.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ControlTower.DAL.Repositories
{
    public class LandingsRepository : ILandingsRepository
    {
        object locker = new object();


        public LandingsRepository()
        {
        }
        public bool AddPlaneToLandings(IPlane plane)
        {
                using (var context = new AirportContext())
                {
                    lock (locker)
                    {
                        if (plane != null && !context.Planes.Any(p => p.FlightNumber == plane.FlightNumber))
                        {
                            context.Planes.Add(plane as PlaneBase);
                            context.SaveChanges();
                        }
                            return true;

                    }
                }
        }
        public IEnumerable<IPlane> GetLandings()
        {
            
                using (var context = new AirportContext())
                {
                    return context.Planes.Where(plane => plane.Departured == false).ToList();
                }       
        }


        public bool UpdatePlane(IPlane plane)
        {
            using (var context = new AirportContext())
            {
                lock (locker)
                {

                        var planeToUpdate = context.Planes.FirstOrDefault(p => p.FlightNumber == plane.FlightNumber);
                        planeToUpdate.HasLanded = plane.HasLanded;
                        planeToUpdate.IsLoaded = plane.IsLoaded;
                        planeToUpdate.HasMaintained = plane.HasMaintained;
                        planeToUpdate.Departured = plane.Departured;
                        context.Planes.Update(planeToUpdate);
                        context.SaveChanges();
                        return true;
                }
            }
        }


    }
}
