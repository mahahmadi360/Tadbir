using Mah.Tadbir.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mah.Tadbir.DAL.EF.Context.EntityConfig
{
    internal class InvoiceEntityConfiguration : BaseEntityConfiguration<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.CustomerName)
                .HasColumnName(ToUnderScore(nameof(Invoice.CustomerName)))
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(a => a.Description)
                .HasColumnName(ToUnderScore(nameof(Invoice.Description)))
                .HasColumnType("nvarchar(MAX)")
                .IsUnicode(true);

            builder.Property(a => a.RegisterDate)
                .HasColumnName(ToUnderScore(nameof(Invoice.RegisterDate)))
                .IsRequired();

            builder.HasMany<InvoiceStuff>(a=> a.InvoiceStuffs)
                .WithOne()
                .HasForeignKey(a=> a.InvoiceId)
               .HasConstraintName("FK_STUFF_INVOICE_INVOICE")
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
