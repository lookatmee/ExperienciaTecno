using ExperienciaTecno.BackEnd.Core.Especificationes.Models;
using ExperienciaTecno.BackEnd.Core.Especificationes.Repositories;
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
