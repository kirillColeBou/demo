using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newApp.Migrations
{
    public partial class AddGospitalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gospitalization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientsId = table.Column<int>(type: "int", nullable: false),
                    CodeGospitalization = table.Column<int>(type: "int", nullable: false),
                    DateGospitalization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurposeGospitalization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conditions = table.Column<bool>(type: "bit", nullable: false),
                    TermGospitalization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gospitalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gospitalization_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gospitalization_PatientsId",
                table: "Gospitalization",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gospitalization");
        }
    }
}
