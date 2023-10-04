using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.health_clinic.Migrations
{
    /// <inheritdoc />
    public partial class db_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatetimeConsulta",
                table: "Consulta",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmacao",
                table: "Consulta",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmacao",
                table: "Consulta");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatetimeConsulta",
                table: "Consulta",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }
    }
}
