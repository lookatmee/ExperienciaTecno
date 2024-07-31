using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos.Manufacturer;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos.Product;
using ExperienciaTecno.BackEnd.Core.Common.Data;
using ExperienciaTecno.BackEnd.Core.Common.Exceptions;
using ExperienciaTecno.BackEnd.Core.Especificationes.Models;
using ExperienciaTecno.BackEnd.Core.Especificationes.Services;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Services.Impl;
using ExperienciaTecno.BackEnd.Core.Product.Models;
using ExperienciaTecno.BackEnd.Core.Product.Services;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDto>> GetById(Guid Id)
        {
            try
            {
                var product = await ProductService.GetById(Id);

                var productDto = Mapper.Map<ProductDto>(product);

                return Ok(productDto);

            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            try
            {
                var product = await ProductService.GetAll();
                var productDto = product.Select(x => Mapper.Map<ProductDto>(x));

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


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

        [HttpPut]
        [Route("modify")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDto>> Modify([FromBody] UpdateProductDto updateProductDto)
        {
            try
            {
                var productToUpdate = await ProductService.GetById(updateProductDto.Id);

                var newProduct = Mapper.Map<Product>(updateProductDto);

                Mapper.Map(newProduct, productToUpdate);

                await ProductService.Update(productToUpdate);

                var specifications = updateProductDto.Specifications.Select(x => Mapper.Map<Especification>(x)).ToList();
                specifications.ForEach (x => x.Product = productToUpdate);
                await EspecificationService.UpdateAll(productToUpdate.Id, specifications);

                await UnitOfWork.CommitAsync();

                var product = await ProductService.GetById(productToUpdate.Id);

                var productDto = Mapper.Map<ProductDto>(product);

                return CreatedAtAction(nameof(Modify), new { id = productToUpdate.Id }, productDto);

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

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var productToSearch = await ProductService.GetById(id);

                await especificationService.Delete(productToSearch.Id);
                await ProductService.Delete(productToSearch.Id);
                await UnitOfWork.CommitAsync();

                return NoContent();
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
