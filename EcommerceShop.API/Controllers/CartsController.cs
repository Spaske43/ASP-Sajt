using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;
using EcommerceShop.Application.UseCases.Queries.Cart;
using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.Application.UseCases.Commands.Cart;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler;
    public CartsController(UseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }

    /// <summary>
    /// Retrieves a list of carts based on search criteria.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving carts.</param>
    /// <returns>List of carts.</returns>
    [HttpGet]
    [Authorize]
    public IActionResult Get([FromQuery] PagedSearch search, [FromServices] IGetCartQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Retrieves a cart by ID.
    /// </summary>
    /// <param name="id">Cart ID.</param>
    /// <param name="query">Query for finding a cart.</param>
    /// <returns>The cart.</returns>
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult Get(int id, [FromServices] IFindCartQuery query)
    {
        var request = new FindRequestDto
        {
            Id = id,
        };
        return Ok(_useCaseHandler.HandleQuery(query, request));
    }

    /// <summary>
    /// Creates a new cart item.
    /// </summary>
    /// <param name="request">Cart item data.</param>
    /// <param name="command">Command for adding a cart item.</param>
    /// <returns>Status code 201 if successful.</returns>
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromBody] CreateCartDto request, [FromServices] IAddCartItemCommand command)
    {
        _useCaseHandler.HandleCommand(command, request);
        return StatusCode(201);
    }


    /// <summary>
    /// Remove item from cart.
    /// </summary>
    /// <param name="id">Cart Item ID.</param>
    /// <param name="command">Command for removing cart item.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpPut("RemoveCartItem/{id}")]
    [Authorize]
    public IActionResult RemoveCartItem(int id, IRemoveCartItemCommand command)
    {
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }

    /// <summary>
    /// Changes the status of a cart.
    /// </summary>
    /// <param name="id">Cart ID.</param>
    /// <param name="command">Command for changing the cart status.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpPut("{id}/ProcessOrder")]
    [Authorize]
    public IActionResult ProcessOrder(int id, IChangeCartStatusCommand command)
    {
        //request.Id = id;
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }

    /// <summary>
    /// Deletes a cart by ID.
    /// </summary>
    /// <param name="id">Cart ID.</param>
    /// <param name="command">Command for deleting a cart.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id, [FromServices] IDeleteCartCommand command)
    {
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
