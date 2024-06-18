using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;
using EcommerceShop.Application.UseCases.Queries.Product;
using EcommerceShop.Application.UseCases.Dto.Product;
using EcommerceShop.Application.UseCases.Commands.Product;
using EcommerceShop.API.Dto;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler;
    public ProductsController(UseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }

    /// <summary>
    /// Retrieves a list of products based on search criteria.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving products.</param>
    /// <returns>List of products.</returns>
    [HttpGet]
    public IActionResult Get([FromQuery] ProductPagedSearch search, [FromServices] IGetProductQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Retrieves a product by ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <param name="query">Query for finding a product.</param>
    /// <returns>The product.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id, [FromServices] IFindProductQuery query)
    {
        var request = new FindRequestDto
        {
            Id = id,
        };
        return Ok(_useCaseHandler.HandleQuery(query, request));
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="request">Product data.</param>
    /// <param name="command">Command for creating a product.</param>
    /// <returns>Status code 201 if successful.</returns>
    [HttpPost]
    [Authorize]
    public IActionResult Post([FromForm] UploadImageDto request, [FromServices] ICreateProductCommand command)
    {
        var guid = Guid.NewGuid();
        var extension = Path.GetExtension(request.Image.FileName);


        var newFileName = guid + extension;

        var path = Path.Combine("wwwroot", "images", newFileName);

        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            request.Image.CopyTo(fileStream);

        }

        request.Img = newFileName;
        _useCaseHandler.HandleCommand(command, request);
        return StatusCode(201);
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <param name="request">Product data to update.</param>
    /// <param name="command">Command for editing a product.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Put(int id, [FromBody] EditProductDto request, [FromServices] IEditProductCommand command)
    {
        request.Id = id;
        _useCaseHandler.HandleCommand(command, request);
        return StatusCode(204);
    }

    /// <summary>
    /// Deletes a product by ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <param name="command">Command for deleting a product.</param>
    /// <returns>Status code 204 if successful.</returns>
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id,  [FromServices] IDeleteProductCommand command)
    {
        _useCaseHandler.HandleCommand(command, id);
        return StatusCode(204);
    }
}
