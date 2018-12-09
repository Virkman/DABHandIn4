using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DABHandIn4.SmartGridInfoRestApi.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elkilde",
                columns: table => new
                {
                    ElkildeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elkilde", x => x.ElkildeId);
                });

            migrationBuilder.CreateTable(
                name: "SmartMeter",
                columns: table => new
                {
                    SmartMeterId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartMeter", x => x.SmartMeterId);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeNavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "SmartEnhed",
                columns: table => new
                {
                    SmartEnhedId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProsumerId = table.Column<long>(nullable: false),
                    SmartMeterId = table.Column<long>(nullable: false),
                    TypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartEnhed", x => x.SmartEnhedId);
                    table.ForeignKey(
                        name: "FK_SmartEnhed_SmartMeter_SmartMeterId",
                        column: x => x.SmartMeterId,
                        principalTable: "SmartMeter",
                        principalColumn: "SmartMeterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmartEnhed_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    AdresseId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vejnavn = table.Column<string>(nullable: true),
                    Husnummer = table.Column<string>(nullable: true),
                    Postnummer = table.Column<string>(nullable: true),
                    Bynavn = table.Column<string>(nullable: true),
                    SmartEnhedId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.AdresseId);
                    table.ForeignKey(
                        name: "FK_Adresse_SmartEnhed_SmartEnhedId",
                        column: x => x.SmartEnhedId,
                        principalTable: "SmartEnhed",
                        principalColumn: "SmartEnhedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Har",
                columns: table => new
                {
                    SmartEnhedId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElkildeId = table.Column<long>(nullable: false),
                    Antal = table.Column<int>(nullable: false),
                    SmartEnhedId1 = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Har", x => x.SmartEnhedId);
                    table.ForeignKey(
                        name: "FK_Har_Elkilde_ElkildeId",
                        column: x => x.ElkildeId,
                        principalTable: "Elkilde",
                        principalColumn: "ElkildeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Har_SmartEnhed_SmartEnhedId1",
                        column: x => x.SmartEnhedId1,
                        principalTable: "SmartEnhed",
                        principalColumn: "SmartEnhedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresse_SmartEnhedId",
                table: "Adresse",
                column: "SmartEnhedId");

            migrationBuilder.CreateIndex(
                name: "IX_Har_ElkildeId",
                table: "Har",
                column: "ElkildeId");

            migrationBuilder.CreateIndex(
                name: "IX_Har_SmartEnhedId1",
                table: "Har",
                column: "SmartEnhedId1");

            migrationBuilder.CreateIndex(
                name: "IX_SmartEnhed_SmartMeterId",
                table: "SmartEnhed",
                column: "SmartMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartEnhed_TypeId",
                table: "SmartEnhed",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropTable(
                name: "Har");

            migrationBuilder.DropTable(
                name: "Elkilde");

            migrationBuilder.DropTable(
                name: "SmartEnhed");

            migrationBuilder.DropTable(
                name: "SmartMeter");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
