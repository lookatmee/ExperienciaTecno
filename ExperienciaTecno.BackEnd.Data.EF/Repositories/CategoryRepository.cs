using ExperienciaTecno.BackEnd.Core.Category.Models;
using ExperienciaTecno.BackEnd.Core.Category.Repositories;
using ExperienciaTecno.BackEnd.Data.EF.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExperienciaTecno.BackEnd.Data.EF.Repositories;

public class CategoryRepository(BackEndDbContext dbContext)
    : GenericEfRepository<Category, BackEndDbContext>(dbContext), ICategoryRepository
{
    public async Task<Category?> GetById(Guid? id)
    {
        var category = await DbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
        return category;
    }
}
