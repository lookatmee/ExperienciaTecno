using ExperienciaTecno.BackEnd.Core.Category.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExperienciaTecno.BackEnd.Data.EF.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

           builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
