using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskYonetimi.EF.Migrations
{
    /// <inheritdoc />
    public partial class RiskYonetimi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IlAdis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlAdis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IsKonus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Konu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsKonus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IsOrtagis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IletisimKisi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsOrtagis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sirkets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VergiNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YetkiliKisi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirkets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anlasmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SirketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anlasmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anlasmas_Sirkets_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnlasmaIls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnlasmaId = table.Column<int>(type: "int", nullable: false),
                    IlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnlasmaIls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnlasmaIls_Anlasmas_AnlasmaId",
                        column: x => x.AnlasmaId,
                        principalTable: "Anlasmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnlasmaIls_IlAdis_IlId",
                        column: x => x.IlId,
                        principalTable: "IlAdis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnlasmaKonus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnlasmaId = table.Column<int>(type: "int", nullable: false),
                    KonuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnlasmaKonus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnlasmaKonus_Anlasmas_AnlasmaId",
                        column: x => x.AnlasmaId,
                        principalTable: "Anlasmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnlasmaKonus_IsKonus_KonuId",
                        column: x => x.KonuId,
                        principalTable: "IsKonus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskAnalizis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnlasmaId = table.Column<int>(type: "int", nullable: false),
                    RiskSeviyesi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RiskPuani = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskAnalizis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskAnalizis_Anlasmas_AnlasmaId",
                        column: x => x.AnlasmaId,
                        principalTable: "Anlasmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnlasmaIls_AnlasmaId",
                table: "AnlasmaIls",
                column: "AnlasmaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnlasmaIls_IlId",
                table: "AnlasmaIls",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_AnlasmaKonus_AnlasmaId",
                table: "AnlasmaKonus",
                column: "AnlasmaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnlasmaKonus_KonuId",
                table: "AnlasmaKonus",
                column: "KonuId");

            migrationBuilder.CreateIndex(
                name: "IX_Anlasmas_SirketId",
                table: "Anlasmas",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAnalizis_AnlasmaId",
                table: "RiskAnalizis",
                column: "AnlasmaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnlasmaIls");

            migrationBuilder.DropTable(
                name: "AnlasmaKonus");

            migrationBuilder.DropTable(
                name: "IsOrtagis");

            migrationBuilder.DropTable(
                name: "RiskAnalizis");

            migrationBuilder.DropTable(
                name: "IlAdis");

            migrationBuilder.DropTable(
                name: "IsKonus");

            migrationBuilder.DropTable(
                name: "Anlasmas");

            migrationBuilder.DropTable(
                name: "Sirkets");
        }
    }
}
