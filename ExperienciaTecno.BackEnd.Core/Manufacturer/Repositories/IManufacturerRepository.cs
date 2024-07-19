using ExperienciaTecno.BackEnd.Core.Common.Repositories;

namespace ExperienciaTecno.BackEnd.Core.Manufacturer.Repositories;

public interface IManufacturerRepository : IGenericRepository<Models.Manufacturer>
{
    Task<Models.Manufacturer?> GetById(Guid? id);
}
