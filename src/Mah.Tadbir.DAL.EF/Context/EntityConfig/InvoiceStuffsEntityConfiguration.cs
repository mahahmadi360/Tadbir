using Mah.Tadbir.DAL.EF.Extensions;
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
                .HasColumnName(nameof(InvoiceStuff.OffPercent).ToUnderScore())
                .HasDefaultValue(0);

            builder.Property(a => a.StuffPrice)
                .HasColumnName(nameof(InvoiceStuff.StuffPrice).ToUnderScore())
                .IsRequired();

            builder.Property(a => a.StuffQuantity)
               .HasColumnName(nameof(InvoiceStuff.StuffQuantity).ToUnderScore())
               .IsRequired();

            builder.Property(a => a.InvoiceId)
                .HasColumnName(nameof(InvoiceStuff.InvoiceId).ToUnderScore())
                .IsRequired();

            builder.Property(a => a.StuffId)
                .HasColumnName(nameof(InvoiceStuff.StuffId).ToUnderScore())
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
