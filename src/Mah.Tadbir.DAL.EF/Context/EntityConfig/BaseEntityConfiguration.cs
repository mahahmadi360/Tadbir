using Mah.Tadbir.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mah.Tadbir.DAL.EF.Context.EntityConfig
{
    internal class BaseEntityConfiguration<T>:
        IEntityTypeConfiguration<T> where T : BaseEntity
    {

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(a => a.Id).HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(a => a.Id);


            var className = typeof(T).Name;
            builder.ToTable($"TB_{ToUnderScore(className)}");
        }

        protected string ToUnderScore(string input)
        {
            var output = Regex.Replace(input, "([A-Z])", "_$0",
                System.Text.RegularExpressions.RegexOptions.Compiled).ToUpper();
            return output.StartsWith("_") ? output.Substring(1) : output;
        }
    }
}
