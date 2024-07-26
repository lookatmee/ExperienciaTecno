using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos.Category;
using ExperienciaTecno.BackEnd.Core.Category.Models;

namespace ExperienciaTecno.BackEnd.Api.Autommapings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, Category>().ForMember(d => d.Id, o => o.Ignore());
    }
}
