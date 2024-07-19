namespace ExperienciaTecno.BackEnd.Core.Manufacturer.Services;

public interface IManufacturerService
{
    Task Add(Models.Manufacturer category);
    Task Update(Models.Manufacturer category);
    Task Delete(Guid id);
    Task<IEnumerable<Models.Manufacturer>> GetAll();
    Task<Models.Manufacturer> GetById(Guid id);
}
