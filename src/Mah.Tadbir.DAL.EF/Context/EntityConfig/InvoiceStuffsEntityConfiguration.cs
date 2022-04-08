using Mah.Tadbir.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mah.Tadbir.DAL.EF.Context.EntityConfig
{
    internal class InvoiceStuffsEntityConfiguration : BaseEntityConfiguration<InvoiceStuffs>
    {
        public override void Configure(EntityTypeBuilder<InvoiceStuffs> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.OffPercent)
                .HasColumnName(ToUnderScore(nameof(InvoiceStuffs.OffPercent)))
                .HasDefaultValue(0);

            builder.Property(a => a.StuffPrice)
                .HasColumnName(ToUnderScore(nameof(InvoiceStuffs.StuffPrice)))
                .IsRequired();

            builder.Property(a => a.StuffQuantity)
               .HasColumnName(ToUnderScore(nameof(InvoiceStuffs.StuffQuantity)))
               .IsRequired();

            builder.HasOne(a => a.Stuff)
                .WithMany()
                .IsRequired()
                .HasForeignKey("STUFF_ID")
                .HasConstraintName("FK_STUFF_INVOICE_STUFF")
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Invoice)
               .WithMany()
               .IsRequired()
               .HasForeignKey("INVOICE_ID")
               .HasConstraintName("FK_STUFF_INVOICE_INVOICE")
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
