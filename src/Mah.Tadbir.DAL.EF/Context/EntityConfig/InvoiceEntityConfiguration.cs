using Mah.Tadbir.DAL.EF.Extensions;
using Mah.Tadbir.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mah.Tadbir.DAL.EF.Context.EntityConfig
{
    internal class InvoiceEntityConfiguration : BaseEntityConfiguration<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.CustomerName)
                .HasColumnName(nameof(Invoice.CustomerName).ToUnderScore())
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(a => a.Description)
                .HasColumnName(nameof(Invoice.Description).ToUnderScore())
                .HasColumnType("nvarchar(MAX)")
                .IsUnicode(true);

            builder.Property(a => a.RegisterDate)
                .HasColumnName(nameof(Invoice.RegisterDate).ToUnderScore())
                .IsRequired();

            builder.HasMany<InvoiceStuff>(a => a.InvoiceStuffs)
                .WithOne()
                .HasForeignKey(a => a.InvoiceId)
               .HasConstraintName("FK_STUFF_INVOICE_INVOICE")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
