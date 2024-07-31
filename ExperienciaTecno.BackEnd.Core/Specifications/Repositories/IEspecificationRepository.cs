using ExperienciaTecno.BackEnd.Core.Common.Repositories;
using ExperienciaTecno.BackEnd.Core.Specifications.Models;

namespace ExperienciaTecno.BackEnd.Core.Specifications.Repositories;

public interface IEspecificationRepository : IGenericRepository<Especification>
{
    Task<IEnumerable<Especification>> GetSpecificationsByProductId(Guid productId);
}
