namespace ExperienciaTecno.BackEnd.Core.Product.Models;

public class Especification
{
    public Guid Id { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }
    public Product? Product { get; set; }
}
