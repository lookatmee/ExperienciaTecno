using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos;
using ExperienciaTecno.BackEnd.Core.Common.Data;
using ExperienciaTecno.BackEnd.Core.Common.Data.Impl;
using ExperienciaTecno.BackEnd.Core.Common.Exceptions;
using ExperienciaTecno.BackEnd.Core.Especificationes.Models;
using ExperienciaTecno.BackEnd.Core.Especificationes.Services;
using ExperienciaTecno.BackEnd.Core.Especificationes.Services.Impl;
using ExperienciaTecno.BackEnd.Core.Product.Models;
using ExperienciaTecno.BackEnd.Core.Product.Services;
using ExperienciaTecno.BackEnd.Core.Product.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExperienciaTecno.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(IProductService productService, IEspecificationService especificationService, IMapper mapper, IUnitOfWork unitOfWork) : Controller
    {
        private IProductService ProductService { get; } = productService;
        private IEspecificationService EspecificationService { get; } = especificationService;
        private IMapper Mapper { get; } = mapper;
        private IUnitOfWork UnitOfWork { get; } = unitOfWork;

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto createProductDto)
        {
            try
            {
                var product = Mapper.Map<Product>(createProductDto);
                await ProductService.Add(product);

                var specifications = createProductDto.Specifications.Select(x => Mapper.Map<Especification>(x)).ToList();
                specifications.ForEach(x => x.Product = product);
                await EspecificationService.AddRangeAsync(specifications);

                await UnitOfWork.CommitAsync();

                var productDto = Mapper.Map<ProductDto>(product);

                return CreatedAtAction(nameof(Create), new { id = product.Id }, productDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
