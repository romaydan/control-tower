using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlTower.DAL.Migrations
{
    public partial class InitServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlightNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    HasLanded = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsLoaded = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasMaintained = table.Column<bool>(type: "INTEGER", nullable: false),
                    Departured = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlaneType = table.Column<int>(type: "INTEGER", nullable: false),
                    CargoWeightInTons = table.Column<int>(type: "INTEGER", nullable: true),
                    Passengers = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeName = table.Column<string>(type: "TEXT", nullable: true),
                    PlaneId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_Facilities_Planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaneId = table.Column<int>(type: "INTEGER", nullable: true),
                    OriginFacilityId = table.Column<int>(type: "INTEGER", nullable: false),
                    DestinationFacilityId = table.Column<int>(type: "INTEGER", nullable: false),
                    OccurrenceDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_PlaneId",
                table: "Facilities",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_PlaneId",
                table: "Logs",
                column: "PlaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}
