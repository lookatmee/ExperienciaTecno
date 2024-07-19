namespace ExperienciaTecno.BackEnd.Core.Manufacturer.Models;

public class Manufacturer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;

    // Navigation property
    public List<Product.Models.Product> Products { get; set; } = new();
}
