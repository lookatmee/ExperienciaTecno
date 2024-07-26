using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos.Category;
using ExperienciaTecno.BackEnd.Core.Category.Models;
using ExperienciaTecno.BackEnd.Core.Category.Services;
using ExperienciaTecno.BackEnd.Core.Common.Data;
using ExperienciaTecno.BackEnd.Core.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ExperienciaTecno.BackEnd.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController(ICategoryService categoryService, IMapper mapper, IUnitOfWork unitOfWork) : Controller
{
    private ICategoryService CategoryService { get; } = categoryService;
    private IMapper Mapper { get; } = mapper;
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryDto>> GetById(Guid categoryId)
    {
        try
        {
            var category = await CategoryService.GetById(categoryId);
            return Ok(Mapper.Map<CategoryDto>(category));
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
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        try
        {
            var categories = await CategoryService.GetAll();
            var categoriesDto = categories.Select(x => Mapper.Map<CategoryDto>(x));

            return Ok(categoriesDto);
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
    public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto createCategoryDto)
    {
        try
        {
            var category = Mapper.Map<Category>(createCategoryDto);
            await CategoryService.Add(category);
            await UnitOfWork.CommitAsync();
            return Ok(Mapper.Map<CategoryDto>(category));
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
    public async Task<ActionResult<CategoryDto>> Modify(UpdateCategoryDto category)
    {
        try
        {
            var categoryToUpdate = await CategoryService.GetById(category.Id);
            var newCategory = Mapper.Map<Category>(category);
            Mapper.Map(newCategory, categoryToUpdate);

            await CategoryService.Update(categoryToUpdate);
            await UnitOfWork.CommitAsync();

            return Ok(Mapper.Map<CategoryDto>(categoryToUpdate));
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
            var categoryToDelete = await CategoryService.GetById(id);
            await CategoryService.Delete(id);
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
