using EcommerceShop.Application.UseCases.Commands.Cart;
using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Queries.Cart;
using EcommerceShop.Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;
using EcommerceShop.Application.UseCases.Queries.Report;
using EcommerceShop.Application.UseCases.Dto.Reports;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly UseCaseHandler _useCaseHandler;

    public ReportsController(UseCaseHandler useCaseHandler)
    {
        _useCaseHandler = useCaseHandler;
    }

    /// <summary>
    /// Retrieves orders report based on search criteria.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving orders report.</param>
    /// <returns>Orders report.</returns>
    [HttpGet("Orders")]
    [Authorize]
    public IActionResult GetOrders([FromQuery] OrderPagedSearch search, [FromServices] IGetOrdersReportQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

    /// <summary>
    /// Retrieves audit logs report based on search criteria.
    /// </summary>
    /// <param name="search">Search criteria.</param>
    /// <param name="query">Query for retrieving audit logs report.</param>
    /// <returns>Audit logs report.</returns>
    [HttpGet("AuditLogs")]
    [Authorize]
    public IActionResult GetAuditLog([FromQuery] AuditLogPagedSearch search, [FromServices] IGetUseCaseLogQuery query)
    {
        return Ok(_useCaseHandler.HandleQuery(query, search));
    }

}
