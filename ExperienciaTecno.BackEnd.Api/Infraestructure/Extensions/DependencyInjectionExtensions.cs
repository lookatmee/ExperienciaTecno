using ExperienciaTecno.BackEnd.Core.Category.Models;
using ExperienciaTecno.BackEnd.Core.Category.Repositories;
using ExperienciaTecno.BackEnd.Core.Category.Services;
using ExperienciaTecno.BackEnd.Core.Category.Services.Impl;
using ExperienciaTecno.BackEnd.Core.Category.Validators;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Models;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Repositories;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Services;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Services.Impl;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Validators;
using ExperienciaTecno.BackEnd.Core.Product.Models;
using ExperienciaTecno.BackEnd.Core.Product.Repositories;
using ExperienciaTecno.BackEnd.Core.Product.Services;
using ExperienciaTecno.BackEnd.Core.Product.Services.Impl;
using ExperienciaTecno.BackEnd.Core.Product.Validators;
using ExperienciaTecno.BackEnd.Data.EF.Repositories;
using FluentValidation;

namespace ExperienciaTecno.BackEnd.Api.Infraestructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.RegisterServices();
        services.RegisterRepositories();
        services.RegisterValidators();
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IManufacturerService, ManufacturerService>();
        services.AddScoped<IProductService, ProductService>();
    }

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<Category>, CategoryValidator>();
        services.AddSingleton<IValidator<Manufacturer>, ManufacturerValidator>();
        services.AddSingleton<IValidator<Product>,ProductValidator>();
    }
}
