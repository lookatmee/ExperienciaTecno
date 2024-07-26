using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos.Manufacturer;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Models;

namespace ExperienciaTecno.BackEnd.Api.Autommapings;

public class ManufacturerProfile : Profile
{
    public ManufacturerProfile()
    {
        CreateMap<Manufacturer, ManufacturerDto>();
        CreateMap<CreateManufacturerDto, Manufacturer>();
        CreateMap<UpdateManufacturerDto,  Manufacturer>();
        CreateMap<Manufacturer,  Manufacturer>().ForMember(d => d.Id, o => o.Ignore());
    }
}
