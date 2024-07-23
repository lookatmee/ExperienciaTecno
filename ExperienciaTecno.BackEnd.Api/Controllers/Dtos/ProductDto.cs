namespace ExperienciaTecno.BackEnd.Api.Controllers.Dtos;

public class ProductDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string VideoPath { get; set; } = null!;
    public string ImagePath1 { get; set; } = null!;
    public string ImagePath2 { get; set; } = null!;
    public string ImagePath3 { get; set; } = null!;
    public List<SpecificationDto>? Specifications { get; set; }
}
