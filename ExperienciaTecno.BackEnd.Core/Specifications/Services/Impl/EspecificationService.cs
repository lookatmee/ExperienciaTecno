using ExperienciaTecno.BackEnd.Core.Specifications.Models;
using ExperienciaTecno.BackEnd.Core.Specifications.Repositories;

namespace ExperienciaTecno.BackEnd.Core.Specifications.Services.Impl;

public class EspecificationService : IEspecificationService
{
    IEspecificationRepository EspecificationRepository { get; }

    public EspecificationService(IEspecificationRepository especificationRepository)
    {
        EspecificationRepository = especificationRepository;
    }

    public async Task AddRangeAsync(List<Especification> specifications)
    {
        if (specifications.Count == 0)
        {
            return;
        }

        await EspecificationRepository.AddRangeAsync(specifications);
    }

    public async Task UpdateAll(Guid productId, List<Especification> specifications)
    {
        var specificationList = await EspecificationRepository.GetSpecificationsByProductId(productId);

        if (specificationList.Any())
        {
            EspecificationRepository.RemoveRange(specificationList);
        }

        await EspecificationRepository.AddRangeAsync(specifications);
    }

    public async Task Delete(Guid productId)
    {
        var specificationList = await EspecificationRepository.GetSpecificationsByProductId(productId);

        if (specificationList.Any())
        {
            EspecificationRepository.RemoveRange(specificationList);
        }
    }
}
