using ExperienciaTecno.BackEnd.Core.Common.Exceptions;
using ExperienciaTecno.BackEnd.Core.Common.Models;
using ExperienciaTecno.BackEnd.Core.Product.Repositories;
using FluentValidation;

namespace ExperienciaTecno.BackEnd.Core.Product.Services.Impl;

public class ProductService(IProductRepository productRepository, IValidator<Models.Product> validator) : IProductService
{
    private IProductRepository ProductRepository { get; } = productRepository;
    public IValidator<Models.Product> Validator { get; } = validator;

    public async Task<Models.Product> GetById(Guid id)
    {
        var product = await ProductRepository.GetById(id);

        if (product is null)
        {
            throw new NotFoundException($"El producto {id} no existe.");
        }
        return product;
    }

    public async Task<IEnumerable<Models.Product>> GetAll()
    {
        var product = await ProductRepository.GetAllAsync();
        return product;
    }

    public async Task Add(Models.Product product)
    {
        var validationProduct = await Validator.ValidateAsync(product);

        if (validationProduct.IsValid)
        {
            throw new ValidationException(validationProduct.Errors);
        }
        await ProductRepository.AddAsync(product);
    }
    public async Task Update(Models.Product product)
    {
        var productToUpdate = await GetById(product.Id);
        var validationProduct = await Validator.ValidateAsync(productToUpdate);
        
        if (validationProduct.IsValid) 
        {
            throw new ValidationException(validationProduct.Errors);
        }
        ProductRepository.Update(productToUpdate);
    }

    public async Task Delete(Guid id)
    {
        var productToDelete = await GetById(id);
        ProductRepository.Remove(productToDelete);
    }
    
    public async Task<KeySetPaginated<Models.Product>> GetAllPaginated(Guid? referenceProductId)
    {
        var productReference = await ProductRepository.GetById(referenceProductId);
        var productsPaginated = await ProductRepository.GetAllPaginated(new KeySetPaginationBase<Models.Product> 
        {
            Reference = productReference
        });
        return productsPaginated;
    }
}
