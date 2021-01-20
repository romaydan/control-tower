using ControlTower.Common.Models.Api;
using ControlTower.Common.Models.DTOs;
using ControlTower.Common.Models.Facilities;
using ControlTower.Common.Models.Logs;
using ControlTower.Common.Models.Planes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.DAL
{
    public class AirportContext : DbContext
    {
        public DbSet<PlaneBase> Planes { get; set; }
        public DbSet<FacilityDTO> Facilities { get; set; }
        public DbSet<CargoPlane> CargoPlanes { get; set; }
        public DbSet<PassengerPlane> PassengerPlanes { get; set; }
        public DbSet<Log> Logs { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ControlTower;").EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite("Data Source=airport.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaneBase>().ToTable("Planes").HasDiscriminator<int>("PlaneType").HasValue<CargoPlane>(1).HasValue<PassengerPlane>(2);
            modelBuilder.Entity<FacilityDTO>().Property(fs => fs.FacilityId).ValueGeneratedNever();
            base.OnModelCreating(modelBuilder);
        }

    }
}
