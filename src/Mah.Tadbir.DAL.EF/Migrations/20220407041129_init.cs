using Microsoft.EntityFrameworkCore.Migrations;

namespace Mah.Tadbir.DAL.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_STUFF",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STUFF_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    STUFF_PRICE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_STUFF", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_STUFF");
        }
    }
}
