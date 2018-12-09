using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DABHandIn4.ProsumerInfoRestApi.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prosumer",
                columns: table => new
                {
                    ProsumerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SmartEnhedId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prosumer", x => x.ProsumerId);
                });

            migrationBuilder.CreateTable(
                name: "Forbrug",
                columns: table => new
                {
                    ForbrugId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AarligkWh = table.Column<int>(nullable: false),
                    Aarstal = table.Column<DateTime>(nullable: false),
                    Kvartal1kWh = table.Column<int>(nullable: true),
                    Kvartal2kWh = table.Column<int>(nullable: true),
                    Kvartal3kWh = table.Column<int>(nullable: true),
                    Kvartal4kWh = table.Column<int>(nullable: true),
                    ProsumerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forbrug", x => x.ForbrugId);
                    table.ForeignKey(
                        name: "FK_Forbrug_Prosumer_ProsumerId",
                        column: x => x.ProsumerId,
                        principalTable: "Prosumer",
                        principalColumn: "ProsumerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAntal",
                columns: table => new
                {
                    PersonAntalId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AntalVoksne = table.Column<int>(nullable: false),
                    ProsumerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAntal", x => x.PersonAntalId);
                    table.ForeignKey(
                        name: "FK_PersonAntal_Prosumer_ProsumerId",
                        column: x => x.ProsumerId,
                        principalTable: "Prosumer",
                        principalColumn: "ProsumerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forbrug_ProsumerId",
                table: "Forbrug",
                column: "ProsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAntal_ProsumerId",
                table: "PersonAntal",
                column: "ProsumerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forbrug");

            migrationBuilder.DropTable(
                name: "PersonAntal");

            migrationBuilder.DropTable(
                name: "Prosumer");
        }
    }
}
