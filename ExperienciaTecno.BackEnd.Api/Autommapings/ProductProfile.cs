using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos;
using ExperienciaTecno.BackEnd.Core.Especificationes.Models;
using ExperienciaTecno.BackEnd.Core.Product.Models;
using System.Security.Cryptography.Xml;

namespace ExperienciaTecno.BackEnd.Api.Autommapings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.Specifications, o => o.MapFrom(src => src.Especifications));
    }
}
