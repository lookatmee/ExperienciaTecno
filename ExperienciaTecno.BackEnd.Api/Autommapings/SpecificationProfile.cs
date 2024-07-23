using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos;
using ExperienciaTecno.BackEnd.Core.Especificationes.Models;

namespace ExperienciaTecno.BackEnd.Api.Autommapings;

public class SpecificationProfile : Profile
{
    public SpecificationProfile()
    {
        CreateMap<SpecificationDto, Especification>().ReverseMap();
    }
}
