using System.Collections.ObjectModel;
using ExperienciaTecno.BackEnd.Core.Especificationes.Models;

namespace ExperienciaTecno.BackEnd.Core.Product.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string VideoPath { get; set; } = null!;
    public string ImagePath1 { get; set; } = null!;
    public string ImagePath2 { get; set; } = null!;
    public string ImagePath3 { get; set; } = null!;    
    public ICollection<Especification>? Especifications { get; set; }
    public bool Enabled { get; set; }
    public Guid ManufacturerId { get; set; }
    public Guid CategoryId { get; set; }
    public Manufacturer.Models.Manufacturer Manufacturer { get; set; } = null!;
    public Category.Models.Category Category { get; set; } = null!;                                  
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
