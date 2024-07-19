using ExperienciaTecno.BackEnd.Core.Category.Repositories;
using ExperienciaTecno.BackEnd.Core.Common.Exceptions;
using FluentValidation;

namespace ExperienciaTecno.BackEnd.Core.Category.Services.Impl;

public class CategoryService(ICategoryRepository categoryRepository, IValidator<Models.Category> validator) : ICategoryService
{
    private ICategoryRepository CategoryRepository { get; } = categoryRepository;
    public IValidator<Models.Category> Validator { get; } = validator;

    public async Task<Models.Category> GetById(Guid id)
    {
        var category = await CategoryRepository.GetById(id);

        if (category is null)
        {
            throw new NotFoundException($"La categoría {id} no existe.");
        }
        return category;
    }

    public async Task<IEnumerable<Models.Category>> GetAll()
    {
        var categories = await CategoryRepository.GetAllAsync();
        return categories;
    }

    public async Task Add(Models.Category category)
    {
        var validationCategory = await Validator.ValidateAsync(category);
        if (validationCategory.IsValid)
        {
            throw new ValidationException(validationCategory.Errors);
        }
        await CategoryRepository.AddAsync(category);
    }

    public async Task Update(Models.Category category)
    {
        var categoryToUpdate = await GetById(category.Id);
        var validationCategory = await Validator.ValidateAsync(categoryToUpdate);

        if (validationCategory.IsValid) 
        {
            throw new ValidationException(validationCategory.Errors);
        }
        CategoryRepository.Update(categoryToUpdate);
    }

    public async Task Delete(Guid id)
    {
        var categoryToDelete = await GetById(id);
        CategoryRepository.Remove(categoryToDelete);
    }
}
