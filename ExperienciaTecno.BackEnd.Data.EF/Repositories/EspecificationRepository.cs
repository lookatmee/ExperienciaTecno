using ExperienciaTecno.BackEnd.Core.Specifications.Models;
using ExperienciaTecno.BackEnd.Core.Specifications.Repositories;
using ExperienciaTecno.BackEnd.Data.EF.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExperienciaTecno.BackEnd.Data.EF.Repositories;

public class EspecificationRepository(BackEndDbContext dbContext)
    : GenericEfRepository<Especification, BackEndDbContext>(dbContext), IEspecificationRepository
{
    public async Task<IEnumerable<Especification>> GetSpecificationsByProductId(Guid productId)
    {
        var specifications = await DbContext.Especification.Where(x => x.Product.Id == productId).ToListAsync();
        return specifications;
    }
}
