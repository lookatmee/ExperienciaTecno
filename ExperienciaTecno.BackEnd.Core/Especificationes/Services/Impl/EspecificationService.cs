using ExperienciaTecno.BackEnd.Core.Especificationes.Models;
using ExperienciaTecno.BackEnd.Core.Especificationes.Repositories;

namespace ExperienciaTecno.BackEnd.Core.Especificationes.Services.Impl;

public class EspecificationService : IEspecificationService
{
    IEspecificationRepository EspecificationRepository { get; }

    public EspecificationService(IEspecificationRepository especificationRepository)
    {
        EspecificationRepository = especificationRepository;
    }

    public Task Add(Especification especification)
    {
        throw new NotImplementedException();
    }

    public async Task AddRangeAsync(List<Especification> specifications)
    {
        if (specifications.Count == 0)
        {
            return;
        }

        await EspecificationRepository.AddRangeAsync(specifications);
    }
}
