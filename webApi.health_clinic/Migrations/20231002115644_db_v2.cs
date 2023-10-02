using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.health_clinic.Migrations
{
    /// <inheritdoc />
    public partial class db_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Medico_CRM",
                table: "Medico",
                column: "CRM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinica_CNPJ",
                table: "Clinica",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinica_RazaoSocial",
                table: "Clinica",
                column: "RazaoSocial",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medico_CRM",
                table: "Medico");

            migrationBuilder.DropIndex(
                name: "IX_Clinica_CNPJ",
                table: "Clinica");

            migrationBuilder.DropIndex(
                name: "IX_Clinica_RazaoSocial",
                table: "Clinica");
        }
    }
}
