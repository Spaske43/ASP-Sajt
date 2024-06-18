using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;
using EcommerceShop.Application.UseCases.Queries.Discount;
using EcommerceShop.Application.UseCases.Dto.Discount;
using EcommerceShop.Application.UseCases.Commands.Discount;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler;
    public DiscountsController(UseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }

    /// <summary>
    /// Retrieves a list of discounts based on search criteria.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving discounts.</param>
    /// <returns>List of discounts.</returns>
    [HttpGet]
    [Authorize]
    public IActionResult Get([FromQuery] DiscountPagedSearch search, [FromServices] IGetDiscountQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Schedules a new discount.
    /// </summary>
    /// <param name="request">Discount data.</param>
    /// <param name="command">Command for scheduling a discount.</param>
    /// <returns>Status code 201 if successful.</returns>
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] ScheduleDiscountDto request, [FromServices] IScheduledDiscountCommand command)
    {
        _useCaseHandler.HandleCommand(command, request);
        return StatusCode(201);
    }

    /// <summary>
    /// Deletes a discount by ID.
    /// </summary>
    /// <param name="id">Discount ID.</param>
    /// <param name="command">Command for deleting a discount.</param>
    /// <returns>Status code 204 if successful.</returns>
    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromServices] IDeleteDiscountCommand command)
    {
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
