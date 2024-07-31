using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos.Product;
using ExperienciaTecno.BackEnd.Core.Product.Models;

namespace ExperienciaTecno.BackEnd.Api.Autommapings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.Specifications, o => o.MapFrom(src => src.Specifications));        
        CreateMap<Product, Product>().ForMember(d => d.Id, o => o.Ignore());
        CreateMap<UpdateProductDto, Product>();
    }
}
