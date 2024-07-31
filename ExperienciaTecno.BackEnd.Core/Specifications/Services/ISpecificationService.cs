using ExperienciaTecno.BackEnd.Core.Specifications.Models;

namespace ExperienciaTecno.BackEnd.Core.Specifications.Services;

public interface ISpecificationService
{
    Task UpdateAll(Guid productId, List<Specification> specifications);
    Task AddRangeAsync(List<Specification> specifications);
    Task Delete(Guid id);
}
