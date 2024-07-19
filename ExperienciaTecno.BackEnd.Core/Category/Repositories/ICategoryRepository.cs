using ExperienciaTecno.BackEnd.Core.Common.Repositories;

namespace ExperienciaTecno.BackEnd.Core.Category.Repositories;

public interface ICategoryRepository : IGenericRepository<Models.Category>
{
    Task<Models.Category?> GetById(Guid? id);
}
