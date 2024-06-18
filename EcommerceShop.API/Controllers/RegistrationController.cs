using EcommerceShop.Application.UseCases.Commands.User;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler;
    public RegistrationController(UseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="request">User registration data.</param>
    /// <param name="command">Command for registering a user.</param>
    /// <returns>Status code 201 if successful.</returns>
    [HttpPost]
    public IActionResult Post([FromBody] RegistrationUserDto request, [FromServices] IRegistrationUserCommand command)
    {
        _useCaseHandler.HandleCommand(command, request);
        return StatusCode(201);
    }

}
