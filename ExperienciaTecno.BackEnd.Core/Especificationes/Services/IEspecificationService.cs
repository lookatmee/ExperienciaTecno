using ExperienciaTecno.BackEnd.Core.Especificationes.Models;

namespace ExperienciaTecno.BackEnd.Core.Especificationes.Services;

public interface IEspecificationService
{
    Task UpdateAll(Guid productId, List<Especification> specifications);
    Task AddRangeAsync(List<Especification> specifications);
}
