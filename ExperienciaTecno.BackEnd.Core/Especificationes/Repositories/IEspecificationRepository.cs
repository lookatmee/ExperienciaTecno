using ExperienciaTecno.BackEnd.Core.Common.Repositories;
using ExperienciaTecno.BackEnd.Core.Especificationes.Models;

namespace ExperienciaTecno.BackEnd.Core.Especificationes.Repositories;

public interface IEspecificationRepository : IGenericRepository<Especification>
{
    Task<IEnumerable<Especification>> GetSpecificationsByProductId(Guid productId);
}
