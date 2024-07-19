namespace ExperienciaTecno.BackEnd.Core.Category.Services;

public interface ICategoryService
{
    Task Add(Models.Category category);
    Task Update(Models.Category category);
    Task Delete(Guid id);
    Task<IEnumerable<Models.Category>> GetAll();
    Task<Models.Category> GetById(Guid id);
}
