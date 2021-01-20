using ControlTower.Common.Models.DTOs;
using ControlTower.DAL.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlTower.DAL.Repositories
{
    public class StateRepository : IStateRepository
    {
        object locker = new object();
        public bool SetFacilitiesState(IList<FacilityDTO> facilitySnapshots)
        {
            using (var context = new AirportContext())
            {
                lock (locker)
                {
                    //SqlLite doesnt have TRUNCATE TABLE and MSSQL has if it fails it means the db is SqlLite
                    try
                    {
                    context.Database.ExecuteSqlRaw("TRUNCATE TABLE Facilities");

                    }
                    catch (Exception)
                    {
                        context.Database.ExecuteSqlRaw("DELETE FROM Facilities");


                    }
                    foreach (var item in facilitySnapshots)
                    {
                        if (item.Plane != null)
                        {
                            var plane = context.Planes.Where(p => p.FlightNumber == item.Plane.FlightNumber).FirstOrDefault();
                            item.Plane = plane;
                        }
                        context.Facilities.Add(item);
                    }
                    context.SaveChanges();
                    return true;
                }

            }
        }
        public IList<FacilityDTO> GetFacilitiesState()
        {
            using (var context = new AirportContext())
            {
                return context.Facilities.Include(f => f.Plane).ToList();
            }
        }
    }
}
