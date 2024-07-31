using ExperienciaTecno.BackEnd.Core.Specifications.Models;

namespace ExperienciaTecno.BackEnd.Core.Specifications.Services;

public interface IEspecificationService
{
    Task UpdateAll(Guid productId, List<Especification> specifications);
    Task AddRangeAsync(List<Especification> specifications);
    Task Delete(Guid id);
}
