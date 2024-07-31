using ExperienciaTecno.BackEnd.Core.Specifications.Models;
using ExperienciaTecno.BackEnd.Core.Specifications.Repositories;

namespace ExperienciaTecno.BackEnd.Core.Specifications.Services.Impl;

public class SpecificationService : ISpecificationService
{
    private ISpecificationRepository SpecificationRepository { get; }

    public SpecificationService(ISpecificationRepository specificationRepository)
    {
        SpecificationRepository = specificationRepository;
    }

    public async Task AddRangeAsync(List<Specification> specifications)
    {
        if (specifications.Count == 0)
        {
            return;
        }

        await SpecificationRepository.AddRangeAsync(specifications);
    }

    public async Task UpdateAll(Guid productId, List<Specification> specifications)
    {
        var specificationList = await SpecificationRepository.GetSpecificationsByProductId(productId);

        if (specificationList.Any())
        {
            SpecificationRepository.RemoveRange(specificationList);
        }

        await SpecificationRepository.AddRangeAsync(specifications);
    }

    public async Task Delete(Guid productId)
    {
        var specificationList = await SpecificationRepository.GetSpecificationsByProductId(productId);

        if (specificationList.Any())
        {
            SpecificationRepository.RemoveRange(specificationList);
        }
    }
}
