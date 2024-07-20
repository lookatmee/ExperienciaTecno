using ExperienciaTecno.BackEnd.Core.Common.Exceptions;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Repositories;
using FluentValidation;

namespace ExperienciaTecno.BackEnd.Core.Manufacturer.Services.Impl;

public class ManufacturerService(IManufacturerRepository manufacturerRepository, IValidator<Models.Manufacturer> validator) : IManufacturerService
{
    private IManufacturerRepository ManufacturerRepository { get; } = manufacturerRepository;
    public IValidator<Models.Manufacturer> Validator { get; } = validator;

    public async Task<Models.Manufacturer> GetById(Guid id)
    {
        var manufacturer = await ManufacturerRepository.GetById(id);

        if (manufacturer is null)
        {
            throw new NotFoundException($"El fabricante {id} no existe.");
        }
        return manufacturer;
    }

    public async Task<IEnumerable<Models.Manufacturer>> GetAll()
    {
        var manufacturer = await ManufacturerRepository.GetAllAsync();
        return manufacturer;
    }

    public async Task Add(Models.Manufacturer manufacturer)
    {
        manufacturer.Id = Guid.NewGuid();
        var validationManufacturer = await Validator.ValidateAsync(manufacturer);

        if (validationManufacturer.IsValid)
        {
            throw new ValidationException(validationManufacturer.Errors);
        }
        await ManufacturerRepository.AddAsync(manufacturer);
    }

    public async Task Update(Models.Manufacturer manufacturer)
    {
        var manufacturerToUpdate = await GetById(manufacturer.Id);
        var validationManufacturer = await Validator.ValidateAsync(manufacturerToUpdate);

        if (validationManufacturer.IsValid)
        {
            throw new ValidationException(validationManufacturer.Errors);
        }
        ManufacturerRepository.Update(manufacturerToUpdate);
    }

    public async Task Delete(Guid id)
    {
        var manufacturerToDelete = await GetById(id);
        ManufacturerRepository.Remove(manufacturerToDelete);
    }    
}
