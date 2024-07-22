namespace ExperienciaTecno.BackEnd.Core.Especificationes.Models;

public class Especification
{
    public Guid Id { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }
    public Product.Models.Product? Product { get; set; }
}
