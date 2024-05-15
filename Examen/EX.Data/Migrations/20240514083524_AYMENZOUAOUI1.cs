using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EX.Data.Migrations
{
    /// <inheritdoc />
    public partial class AYMENZOUAOUI1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.clientId);
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    intule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "prestataires",
                columns: table => new
                {
                    prestataireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appreciation = table.Column<int>(type: "int", nullable: false),
                    prestataireNom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    prestatairePhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prestataireTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarifHoriare = table.Column<double>(type: "float", nullable: false),
                    specialiteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestataires", x => x.prestataireId);
                    table.ForeignKey(
                        name: "FK_prestataires_Specialites_specialiteFK",
                        column: x => x.specialiteFK,
                        principalTable: "Specialites",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "presations",
                columns: table => new
                {
                    HeureRDV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prestataireFK = table.Column<int>(type: "int", nullable: false),
                    clientFK = table.Column<int>(type: "int", nullable: false),
                    nbHeures = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presations", x => new { x.clientFK, x.prestataireFK, x.HeureRDV });
                    table.ForeignKey(
                        name: "FK_presations_clients_clientFK",
                        column: x => x.clientFK,
                        principalTable: "clients",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_presations_prestataires_prestataireFK",
                        column: x => x.prestataireFK,
                        principalTable: "prestataires",
                        principalColumn: "prestataireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_presations_prestataireFK",
                table: "presations",
                column: "prestataireFK");

            migrationBuilder.CreateIndex(
                name: "IX_prestataires_specialiteFK",
                table: "prestataires",
                column: "specialiteFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "presations");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "prestataires");

            migrationBuilder.DropTable(
                name: "Specialites");
        }
    }
}
