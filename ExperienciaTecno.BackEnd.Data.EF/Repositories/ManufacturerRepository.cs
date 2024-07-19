using ExperienciaTecno.BackEnd.Core.Manufacturer.Models;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Repositories;
using ExperienciaTecno.BackEnd.Data.EF.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExperienciaTecno.BackEnd.Data.EF.Repositories;

public class ManufacturerRepository(BackEndDbContext dbContext)
    : GenericEfRepository<Manufacturer, BackEndDbContext>(dbContext), IManufacturerRepository
{
    public async Task<Manufacturer?> GetById(Guid? id)
    {
        var manufacturer  = await DbContext.Manufacturers.SingleOrDefaultAsync(x => x.Id == id);
        return manufacturer;
    }
}
