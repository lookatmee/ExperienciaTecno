namespace ExperienciaTecno.BackEnd.Core.Category.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    // Navigation property
    public List<Product.Models.Product> Products { get; set; } = new();
}
