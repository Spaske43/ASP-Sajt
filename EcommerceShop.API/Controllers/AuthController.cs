using EcommerceShop.API.Core;
using EcommerceShop.API.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtTokenCreator _tokenCreator;

    public AuthController(JwtTokenCreator tokenCreator)
    {
        _tokenCreator = tokenCreator;
    }

    /// <summary>
    /// Creates a token.
    /// </summary>
    /// <returns>Generated token</returns>
    [HttpPost]
    public IActionResult Post([FromBody] AuthRequest request)
    {
        string token = _tokenCreator.Create(request.Email, request.Password);

        return Ok(new AuthResponse { Token = token });
    }

    /// <summary>
    /// Deletes a token.
    /// </summary>
    /// <returns>204 No content</returns>
    [Authorize]
    [HttpDelete]
    public IActionResult Delete([FromServices] ITokenStorage storage)
    {
        storage.Remove(this.Request.GetTokenId().Value);

        return NoContent();
    }
}
