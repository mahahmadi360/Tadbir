using Mah.Tadbir.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mah.Tadbir.DAL.EF.Context.EntityConfig
{
    internal class StuffEntityConfiguration:BaseEntityConfiguration<Stuff>
    {
        public override void Configure(EntityTypeBuilder<Stuff> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Name)
                .HasColumnName("STUFF_NAME")
                .HasMaxLength(250)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(a => a.Price)
                .HasColumnName("STUFF_PRICE")
                .IsRequired(true);
                
        }
    }
}
