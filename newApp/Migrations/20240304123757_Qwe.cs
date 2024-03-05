using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newApp.Migrations
{
    public partial class Qwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEvent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentDiagnosticActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientsId = table.Column<int>(type: "int", nullable: false),
                    DateActivities = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeEventId = table.Column<int>(type: "int", nullable: false),
                    NameActivities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentDiagnosticActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentDiagnosticActivities_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentDiagnosticActivities_TypeEvent_TypeEventId",
                        column: x => x.TypeEventId,
                        principalTable: "TypeEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentDiagnosticActivities_PatientsId",
                table: "TreatmentDiagnosticActivities",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentDiagnosticActivities_TypeEventId",
                table: "TreatmentDiagnosticActivities",
                column: "TypeEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentDiagnosticActivities");

            migrationBuilder.DropTable(
                name: "TypeEvent");
        }
    }
}
