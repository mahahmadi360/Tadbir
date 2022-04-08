using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mah.Tadbir.DAL.EF.Migrations
{
    public partial class AddInvoiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_INVOICE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_NAME = table.Column<string>(maxLength: 300, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "TEXT", nullable: true),
                    REGISTEER_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_INVOICE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_INVOICE_STUFFS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INVOICE_ID = table.Column<int>(nullable: false),
                    STUFF_ID = table.Column<int>(nullable: false),
                    STUFF_QUANTITY = table.Column<double>(nullable: false),
                    STUFF_PRICE = table.Column<double>(nullable: false),
                    OFF_PERCENT = table.Column<double>(nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_INVOICE_STUFFS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STUFF_INVOICE_INVOICE",
                        column: x => x.INVOICE_ID,
                        principalTable: "TB_INVOICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STUFF_INVOICE_STUFF",
                        column: x => x.STUFF_ID,
                        principalTable: "TB_STUFF",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_INVOICE_STUFFS_INVOICE_ID",
                table: "TB_INVOICE_STUFFS",
                column: "INVOICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_INVOICE_STUFFS_STUFF_ID",
                table: "TB_INVOICE_STUFFS",
                column: "STUFF_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_INVOICE_STUFFS");

            migrationBuilder.DropTable(
                name: "TB_INVOICE");
        }
    }
}
