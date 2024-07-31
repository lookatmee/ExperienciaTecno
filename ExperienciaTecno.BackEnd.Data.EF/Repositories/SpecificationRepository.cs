using ExperienciaTecno.BackEnd.Core.Specifications.Models;
using ExperienciaTecno.BackEnd.Core.Specifications.Repositories;
using ExperienciaTecno.BackEnd.Data.EF.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExperienciaTecno.BackEnd.Data.EF.Repositories;

public class SpecificationRepository(BackEndDbContext dbContext)
    : GenericEfRepository<Specification, BackEndDbContext>(dbContext), ISpecificationRepository
{
    public async Task<IEnumerable<Specification>> GetSpecificationsByProductId(Guid productId)
    {
        var specifications = await DbContext.Specifications.Where(x => x.Product.Id == productId).ToListAsync();
        return specifications;
    }
}
