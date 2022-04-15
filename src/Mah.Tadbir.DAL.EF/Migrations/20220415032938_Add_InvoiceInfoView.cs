using Microsoft.EntityFrameworkCore.Migrations;

namespace Mah.Tadbir.DAL.EF.Migrations
{
    public partial class Add_InvoiceInfoView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"CREATE VIEW VW_INVOICE_INFO AS "
                + " SELECT TI.ID, TI.CUSTOMER_NAME, TI.DESCRIPTION, TI.REGISTER_DATE"
                + " , SI.STUFF_COUNT, SI.BENEFIT_PRICE, SI.TOTAL_PRICE"
                + " FROM("
                + " SELECT I.ID, COUNT(1) STUFF_COUNT,"
                + " SUM(S.STUFF_PRICE * S.STUFF_QUANTITY) TOTAL_PRICE,"
                + " SUM(S.STUFF_PRICE * S.STUFF_QUANTITY * S.OFF_PERCENT / 100) BENEFIT_PRICE"
                + " FROM TB_INVOICE_STUFF S,"
                + " TB_INVOICE I"
                + " WHERE I.ID = S.INVOICE_ID"
                + " GROUP BY I.ID) SI,"
                + " TB_INVOICE TI"
                + " WHERE TI.ID = SI.ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW VW_INVOICE_INFO");
        }
    }
}
