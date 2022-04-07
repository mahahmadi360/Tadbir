using Mah.Tadbir.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace Mah.Tadbir.DAL.EF.Context.EntityConfig
{
    internal class BaseEntityConfiguration<T,S> 
        : IEntityTypeConfiguration<T> where T : BaseEntity<S> where S : struct
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(a => a.Id).HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(a => a.Id);


            var className = typeof(T).Name.ToUpper() ;
            builder.ToTable($"TB_{className}");
        }
    }

    internal class BaseEntityConfiguration<T>
        : BaseEntityConfiguration<T,int>, 
        IEntityTypeConfiguration<T> where T : BaseEntity<int>
    {
    }
}
