using EcommerceShop.Application.UseCases.Commands.Category;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Category;
using EcommerceShop.Application.UseCases.Queries.Category;
using EcommerceShop.Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler;
    public CategoriesController(UseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }
    /// <summary>
    /// Retrieves a list of categories based on search criteria.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving categories.</param>
    /// <returns>List of categories.</returns>
    [HttpGet]
    public IActionResult Get([FromQuery] PagedSearch search, [FromServices] IGetCategoryQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Retrieves a category by ID.
    /// </summary>
    /// <param name="id">Category ID.</param>
    /// <param name="query">Query for finding a category.</param>
    /// <returns>The category.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id, [FromServices] IFindCategoryQuery query)
    {
        var request = new FindRequestDto
        {
            Id = id,
        };
        return Ok(_useCaseHandler.HandleQuery(query, request));
    }


    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="dto">Category data.</param>
    /// <param name="command">Command for creating a category.</param>
    /// <returns>Status code 201 if successful.</returns>
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] CreateCategoryDto dto, [FromServices] ICreateCategoryCommand command)
    {
        _useCaseHandler.HandleCommand(command, dto);
        return StatusCode(201);
    }
}
