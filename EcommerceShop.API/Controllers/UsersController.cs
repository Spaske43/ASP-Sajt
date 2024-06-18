using EcommerceShop.Application.UseCases.Commands.User;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.Application.UseCases.Queries.User;
using EcommerceShop.Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler;

    public UsersController(UseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }

    /// <summary>
    /// Retrieves a list of users based on search criteria.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving users.</param>
    /// <returns>List of users.</returns>
    [HttpGet]
    public IActionResult Get([FromQuery] PagedSearch search, [FromServices] IGetUsersQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Retrieves a user by ID.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <param name="query">Query for finding a user.</param>
    /// <returns>The user.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id, [FromServices] IFindUserQuery query)
    {
        var request = new FindRequestDto
        {
            Id = id,
        };
        return Ok(_useCaseHandler.HandleQuery(query, request));
    }

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <param name="request">User data to update.</param>
    /// <param name="command">Command for editing a user.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Put(int id, [FromBody] EditUserDto request, [FromServices] IEditUserCommand command)
    {
        request.Id = id;
        _useCaseHandler.HandleCommand(command, request);
        return StatusCode(204);
    }

    /// <summary>
    /// Updates an access for user.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <param name="command">Command for editing a access user.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpPut("{id}/access")]
    public IActionResult ModifyAccess(int id, [FromBody] EditUserAccessDto dto,
                                              [FromServices] IEditUserAccessCommand command)
    {
        dto.UserId = id;
        _useCaseHandler.HandleCommand(command, dto);

        return NoContent();
    }

    /// <summary>
    /// Deletes a user by ID.
    /// </summary>
    /// <param name="id">User ID.</param>
    /// <param name="command">Command for deleting a user.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
    {
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
