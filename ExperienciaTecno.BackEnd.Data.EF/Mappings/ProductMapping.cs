using ExperienciaTecno.BackEnd.Core.Product.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExperienciaTecno.BackEnd.Data.EF.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id)
                .IsRequired();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.VideoPath)
            .HasMaxLength(200);

        builder.Property(p => p.ImagePath1)
            .HasMaxLength(200);

        builder.Property(p => p.ImagePath2)
            .HasMaxLength(200);

        builder.Property(p => p.ImagePath3);

        // Configuración de la propiedad Enabled
        builder.Property(p => p.Enabled)
            .IsRequired();
    }
}
