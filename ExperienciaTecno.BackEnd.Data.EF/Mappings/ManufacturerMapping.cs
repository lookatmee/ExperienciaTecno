using ExperienciaTecno.BackEnd.Core.Manufacturer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExperienciaTecno.BackEnd.Data.EF.Mappings;

public class ManufacturerMapping : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.Property(m => m.Id)
                .IsRequired();

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Address)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(m => m.Phone)
            .IsRequired()
            .HasMaxLength(15);
    }
}
