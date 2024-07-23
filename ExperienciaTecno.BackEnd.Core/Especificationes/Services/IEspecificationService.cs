using ExperienciaTecno.BackEnd.Core.Especificationes.Models;

namespace ExperienciaTecno.BackEnd.Core.Especificationes.Services;

public interface IEspecificationService
{
    Task Add(Especification especification);
    Task AddRangeAsync(List<Especification> specifications);
}
