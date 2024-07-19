using ExperienciaTecno.BackEnd.Core.Common.Models;

namespace ExperienciaTecno.BackEnd.Core.Product.Services;

public interface IProductService
{
    Task Add(Models.Product product);
    Task Update(Models.Product product);
    Task Delete(Guid id);
    Task<IEnumerable<Models.Product>> GetAll();
    Task<Models.Product> GetById(Guid id);
    Task<KeySetPaginated<Models.Product>> GetAllPaginated(Guid? referenceProductId);
}
