using Mah.Tadbir.DAL.EF.Extensions;
using Mah.Tadbir.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mah.Tadbir.DAL.EF.Context.EntityConfig
{
    internal class InvoiceInfoEntityConfiguration : IEntityTypeConfiguration<InvoiceInfo>
    {
        public void Configure(EntityTypeBuilder<InvoiceInfo> builder)
        {
            builder.ToView("VW_INVOICE_INFO");

            builder.Property(a => a.Id)
                .HasColumnName(nameof(InvoiceInfo.Id).ToUnderScore());

            builder.Property(a => a.CustomerName)
                .HasColumnName(nameof(InvoiceInfo.CustomerName).ToUnderScore());

            builder.Property(a => a.Description)
                .HasColumnName(nameof(InvoiceInfo.Description).ToUnderScore())
                .HasColumnType("nvarchar(MAX)");

            builder.Property(a => a.RegisterDate)
                .HasColumnName(nameof(InvoiceInfo.RegisterDate).ToUnderScore());

            builder.Property(a => a.StuffCount)
               .HasColumnName(nameof(InvoiceInfo.StuffCount).ToUnderScore());

            builder.Property(a => a.TotalPrice)
               .HasColumnName(nameof(InvoiceInfo.TotalPrice).ToUnderScore());

            builder.Property(a => a.BenefitPrice)
               .HasColumnName(nameof(InvoiceInfo.BenefitPrice).ToUnderScore());
        }
    }
}
