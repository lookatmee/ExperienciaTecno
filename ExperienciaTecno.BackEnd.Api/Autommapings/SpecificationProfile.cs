using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos.Specification;
using ExperienciaTecno.BackEnd.Core.Specifications.Models;

namespace ExperienciaTecno.BackEnd.Api.Autommapings;

public class SpecificationProfile : Profile
{
    public SpecificationProfile()
    {
        CreateMap<SpecificationDto, Specification>().ReverseMap();
    }
}
