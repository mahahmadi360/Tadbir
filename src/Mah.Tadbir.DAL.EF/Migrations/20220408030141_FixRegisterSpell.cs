using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mah.Tadbir.DAL.EF.Migrations
{
    public partial class FixRegisterSpell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REGISTEER_DATE",
                table: "TB_INVOICE");

            migrationBuilder.AddColumn<DateTime>(
                name: "REGISTER_DATE",
                table: "TB_INVOICE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REGISTER_DATE",
                table: "TB_INVOICE");

            migrationBuilder.AddColumn<DateTime>(
                name: "REGISTEER_DATE",
                table: "TB_INVOICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
