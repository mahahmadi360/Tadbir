using Mah.Tadbir.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mah.Tadbir.DAL.EF.Context.EntityConfig
{
    internal class InvoiceStuffsEntityConfiguration : BaseEntityConfiguration<InvoiceStuff>
    {
        public override void Configure(EntityTypeBuilder<InvoiceStuff> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.OffPercent)
                .HasColumnName(ToUnderScore(nameof(InvoiceStuff.OffPercent)))
                .HasDefaultValue(0);

            builder.Property(a => a.StuffPrice)
                .HasColumnName(ToUnderScore(nameof(InvoiceStuff.StuffPrice)))
                .IsRequired();

            builder.Property(a => a.StuffQuantity)
               .HasColumnName(ToUnderScore(nameof(InvoiceStuff.StuffQuantity)))
               .IsRequired();

            builder.Property(a => a.InvoiceId)
                .HasColumnName(ToUnderScore(nameof(InvoiceStuff.InvoiceId)))
                .IsRequired();

            builder.Property(a => a.StuffId)
                .HasColumnName(ToUnderScore(nameof(InvoiceStuff.StuffId)))
                .IsRequired();

            builder.HasOne(a => a.Stuff)
                .WithMany()
                .IsRequired()
                .HasForeignKey(a=> a.StuffId)
                .HasConstraintName("FK_STUFF_INVOICE_STUFF")
               .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
