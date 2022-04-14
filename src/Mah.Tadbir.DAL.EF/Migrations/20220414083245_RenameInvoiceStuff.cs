using Microsoft.EntityFrameworkCore.Migrations;

namespace Mah.Tadbir.DAL.EF.Migrations
{
    public partial class RenameInvoiceStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("TB_INVOICE_STUFFS",
                newName: "TB_INVOICE_STUFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_INVOICE_STUFF");

            migrationBuilder.CreateTable(
                name: "TB_INVOICE_STUFFS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INVOICE_ID = table.Column<int>(type: "int", nullable: false),
                    OFF_PERCENT = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    STUFF_ID = table.Column<int>(type: "int", nullable: false),
                    STUFF_PRICE = table.Column<double>(type: "float", nullable: false),
                    STUFF_QUANTITY = table.Column<double>(type: "float", nullable: false)
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
    }
}
