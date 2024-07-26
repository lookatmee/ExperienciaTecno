using AutoMapper;
using ExperienciaTecno.BackEnd.Api.Controllers.Dtos;
using ExperienciaTecno.BackEnd.Core.Common.Data;
using ExperienciaTecno.BackEnd.Core.Common.Exceptions;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Models;
using ExperienciaTecno.BackEnd.Core.Manufacturer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExperienciaTecno.BackEnd.Api.Controllers;

[ApiController]
[Route("api/manufacturers")]
public class ManufacturerController(IManufacturerService manufacturerService, IMapper mapper, IUnitOfWork unitOfWork) : Controller
{
    private IManufacturerService ManufacturerService { get; } = manufacturerService;
    private IMapper Mapper { get; } = mapper;
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ManufacturerDto>> GetById(Guid manufacturerId)
    {
        try
        {
            var manufacturer = await ManufacturerService.GetById(manufacturerId);
            return Ok(Mapper.Map<ManufacturerDto>(manufacturer));
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
    public async Task<ActionResult<IEnumerable<ManufacturerDto>>> GetAll()
    {
        try
        {
            var manufacturer = await ManufacturerService.GetAll();
            var manufacturerDto = manufacturer.Select(x => Mapper.Map<ManufacturerDto>(x));

            return Ok(manufacturerDto);
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
    public async Task<ActionResult<ManufacturerDto>> Create(CreateManufacturerDto createManufacturerDto)
    {
        try
        {
            var manufacturer = Mapper.Map<Manufacturer>(createManufacturerDto);
            await ManufacturerService.Add(manufacturer);
            await UnitOfWork.CommitAsync();
            return Ok(Mapper.Map<ManufacturerDto>(manufacturer));
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
    public async Task<ActionResult<ManufacturerDto>> Modify(UpdateManufacturerDto manufacturer)
    {
        try
        {
            var manufacturerToUpdate = await ManufacturerService.GetById(manufacturer.Id);
            var newManufacturer = Mapper.Map<Manufacturer>(manufacturer);
            Mapper.Map(newManufacturer, manufacturerToUpdate);

            await ManufacturerService.Update(manufacturerToUpdate);
            await UnitOfWork.CommitAsync();

            return Ok(Mapper.Map<ManufacturerDto>(manufacturerToUpdate));
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
            var manufacturerToSearch = await ManufacturerService.GetById(id);
            await ManufacturerService.Delete(id);
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
