using EcommerceShop.Application;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.Application.UseCases.Queries.Cart;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Cart;
public class EfGetCartQuery : IGetCartQuery
{
    private readonly DatabaseContext _databaseContext;
    private readonly IApplicationActor _actor;
    public EfGetCartQuery(DatabaseContext databaseContext, IApplicationActor actor)
    {
        _databaseContext = databaseContext;
        _actor = actor;
    }

    public int Id => 33;

    public string Name => "Get All purchase for logged in user.";

    public PagedResponse<GetCartDto> Execute(PagedSearch search)
    {

        var query = _databaseContext.Carts.Where(x => x.UserId == _actor.Id).AsQueryable();

        int totalCount = query.Count();

        int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
        int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

        int skip = perPage * (page - 1);

        query = query.Skip(skip).Take(perPage);

        return new PagedResponse<GetCartDto>
        {
            CurrentPage = page,
            Data = query.Select(x => new GetCartDto
            {
                Id = x.Id,
                NumberOfItems = x.CartItems.Count,
                Status = x.CartStatus.Name,
                ConfirmedAt = x.ConfirmedAt,
                CreatedAt = x.CreatedAt,
                TotalPrice = x.TotalPrice,
                UpdatedAt = x.UpdatedAt,
            }).ToList(),
            PerPage = perPage,
            TotalCount = totalCount,
        };
    }
}
