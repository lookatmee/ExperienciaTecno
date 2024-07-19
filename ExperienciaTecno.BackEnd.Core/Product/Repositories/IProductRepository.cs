using ExperienciaTecno.BackEnd.Core.Common.Models;
using ExperienciaTecno.BackEnd.Core.Common.Repositories;

namespace ExperienciaTecno.BackEnd.Core.Product.Repositories;

public interface IProductRepository : IGenericRepository<Models.Product>
{
    Task<Models.Product?> GetById(Guid? id);
    Task<KeySetPaginated<Models.Product>> GetAllPaginated(KeySetPaginationBase<Models.Product> options);
}
