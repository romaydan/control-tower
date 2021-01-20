﻿// <auto-generated />
using System;
using ControlTower.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlTower.DAL.Migrations
{
    [DbContext(typeof(AirportContext))]
    [Migration("20201203095718_InitServer")]
    partial class InitServer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ControlTower.Common.Models.DTOs.FacilityDTO", b =>
                {
                    b.Property<int>("FacilityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlaneId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeName")
                        .HasColumnType("TEXT");

                    b.HasKey("FacilityId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("ControlTower.Common.Models.Logs.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DestinationFacilityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OccurrenceDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("OriginFacilityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlaneId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlaneId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("ControlTower.Common.Models.Planes.PlaneBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Departured")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasLanded")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasMaintained")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLoaded")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlaneType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Planes");

                    b.HasDiscriminator<int>("PlaneType");
                });

            modelBuilder.Entity("ControlTower.Common.Models.Planes.CargoPlane", b =>
                {
                    b.HasBaseType("ControlTower.Common.Models.Planes.PlaneBase");

                    b.Property<int>("CargoWeightInTons")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ControlTower.Common.Models.Planes.PassengerPlane", b =>
                {
                    b.HasBaseType("ControlTower.Common.Models.Planes.PlaneBase");

                    b.Property<int>("Passengers")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ControlTower.Common.Models.DTOs.FacilityDTO", b =>
                {
                    b.HasOne("ControlTower.Common.Models.Planes.PlaneBase", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("ControlTower.Common.Models.Logs.Log", b =>
                {
                    b.HasOne("ControlTower.Common.Models.Planes.PlaneBase", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId");

                    b.Navigation("Plane");
                });
#pragma warning restore 612, 618
        }
    }
}
