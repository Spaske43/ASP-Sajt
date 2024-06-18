using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;
using EcommerceShop.Application.UseCases.Queries.Brand;
using EcommerceShop.Application.UseCases.Dto.Brand;
using EcommerceShop.Application.UseCases.Commands.Brand;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler;
    public BrandsController(UseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }

    /// <summary>
    /// Retrieves a list of brands based on search criteria.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving brands.</param>
    /// <returns>List of brands.</returns>
    [HttpGet]
    public IActionResult Get([FromQuery] PagedSearch search, [FromServices] IGetBrandQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }


    /// <summary>
    /// Retrieves a brand by ID.
    /// </summary>
    /// <param name="id">Brand ID.</param>
    /// <param name="query">Query for finding a brand.</param>
    /// <returns>The brand.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id, [FromServices] IFindBrandQuery query)
    {
        var request = new FindRequestDto
        {
            Id = id,
        };
        return Ok(_useCaseHandler.HandleQuery(query, request));
    }

    /// <summary>
    /// Creates a new brand.
    /// </summary>
    /// <param name="request">Brand data.</param>
    /// <param name="command">Command for creating a brand.</param>
    /// <returns>Status code 201 if successful.</returns>
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] CreateBrandDto request, [FromServices] ICreateBrandCommand command)
    {
        _useCaseHandler.HandleCommand(command, request);
        return StatusCode(201);
    }

    /// <summary>
    /// Deletes a brand by ID.
    /// </summary>
    /// <param name="id">Brand ID.</param>
    /// <param name="command">Command for deleting a brand.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
    {
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
