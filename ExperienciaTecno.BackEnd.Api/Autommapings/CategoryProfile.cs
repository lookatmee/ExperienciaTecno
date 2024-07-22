using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos;
using ExperienciaTecno.BackEnd.Core.Category.Models;

namespace ExperienciaTecno.BackEnd.Api.Autommapings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
    }
}
