using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EX.Data.Migrations
{
    /// <inheritdoc />
    public partial class typeenum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tel",
                table: "clients",
                newName: "Cooredonnnes_tel");

            migrationBuilder.RenameColumn(
                name: "prenom",
                table: "clients",
                newName: "Cooredonnnes_prenom");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "clients",
                newName: "Cooredonnnes_nom");

            migrationBuilder.RenameColumn(
                name: "adresse",
                table: "clients",
                newName: "Cooredonnnes_adresse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cooredonnnes_tel",
                table: "clients",
                newName: "tel");

            migrationBuilder.RenameColumn(
                name: "Cooredonnnes_prenom",
                table: "clients",
                newName: "prenom");

            migrationBuilder.RenameColumn(
                name: "Cooredonnnes_nom",
                table: "clients",
                newName: "nom");

            migrationBuilder.RenameColumn(
                name: "Cooredonnnes_adresse",
                table: "clients",
                newName: "adresse");
        }
    }
}
