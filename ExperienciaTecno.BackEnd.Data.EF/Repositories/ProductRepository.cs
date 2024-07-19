using ExperienciaTecno.BackEnd.Core.Common.Models;
using ExperienciaTecno.BackEnd.Core.Product.Models;
using ExperienciaTecno.BackEnd.Core.Product.Repositories;
using ExperienciaTecno.BackEnd.Data.EF.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using MR.EntityFrameworkCore.KeysetPagination;

namespace ExperienciaTecno.BackEnd.Data.EF.Repositories;

public class ProductRepository(BackEndDbContext dbContext)
    : GenericEfRepository<Product, BackEndDbContext>(dbContext), IProductRepository
{
    public async Task<KeySetPaginated<Product>> GetAllPaginated(KeySetPaginationBase<Product> options)
    {
        var quotesQuery = DbContext.Products.AsQueryable();

        var queryContext = quotesQuery.KeysetPaginate(
            KeysetQuery.Build<Product>(b => b.Ascending(x => x.Id).Descending(x => x.CreatedAt)),
            KeysetPaginationDirection.Forward,
            options.Reference);

        var productList = await queryContext.Query.Take(options.PageSize).ToListAsync();

        queryContext.EnsureCorrectOrder(productList);

        return new KeySetPaginated<Product>
        {
            Data = productList,
            HasNext = await queryContext.HasNextAsync(productList),
            HasPrevious = await queryContext.HasPreviousAsync(productList)
        };
    }

    public async Task<Product?> GetById(Guid? id)
    {
        var product = await DbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        return product;
    }
}
