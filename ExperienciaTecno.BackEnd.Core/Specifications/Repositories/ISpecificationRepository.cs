using ExperienciaTecno.BackEnd.Core.Common.Repositories;
using ExperienciaTecno.BackEnd.Core.Specifications.Models;

namespace ExperienciaTecno.BackEnd.Core.Specifications.Repositories;

public interface ISpecificationRepository : IGenericRepository<Specification>
{
    Task<IEnumerable<Specification>> GetSpecificationsByProductId(Guid productId);
}
