using EcommerceShop.Application.UseCases;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.Application.UseCases.Dto.Reports;
using EcommerceShop.Application.UseCases.Queries.Report;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Report;
public class EfGetOrdersReportQuery : IGetOrdersReportQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfGetOrdersReportQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 31;

    public string Name => "Get all confirmed purchase";

    public PagedResponse<GetOrdersDto> Execute(OrderPagedSearch search)
    {
        var query = _databaseContext.Carts.Where(x => x.CartStatusId == 2).AsQueryable();

        if (search.StartConfirmedAt.HasValue)
        {
            query = query.Where(x => x.ConfirmedAt >= search.StartConfirmedAt);
        }
        if (search.EndConfirmedAt.HasValue)
        {
            query = query.Where(x => x.ConfirmedAt <= search.EndConfirmedAt);
        }

        if (!string.IsNullOrEmpty(search.Keyword))
        {
            query = query.Where(x => x.User.Username.Contains(search.Keyword) || 
                                     x.User.Email.Contains(search.Keyword) ||
                                     x.User.FirstName.Contains(search.Keyword) ||
                                     x.User.LastName.Contains(search.Keyword));
        }

        if (search.MinTotalPrice.HasValue)
        {
            query = query.Where(x => x.TotalPrice >= search.MinTotalPrice);
        }

        if (search.MaxTotalPrice.HasValue)
        {
            query = query.Where(x => x.TotalPrice <= search.MaxTotalPrice);
        }

        if (search.MinItemCount.HasValue)
        {
            query = query.Where(x => x.CartItems.Count() >= search.MinItemCount);
        }

        if (search.MaxItemCount.HasValue)
        {
            query = query.Where(x => x.CartItems.Count() <= search.MaxItemCount);
        }

        int totalCount = query.Count();

        int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
        int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

        int skip = perPage * (page - 1);

        query = query.Skip(skip).Take(perPage);

        return new PagedResponse<GetOrdersDto>
        {
            CurrentPage = page,
            Data = query.Select(x => new GetOrdersDto
            {
                Id = x.Id,
                UserEmail = x.User.Email,
                TotalPrice = x.TotalPrice,
                Status = x.CartStatus.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                NumberOfItems = x.CartItems.Count,
                Items = x.CartItems.Select(x => new CartItemDto
                {
                    Id = x.Id,
                    Name = x.Product.Brand.Name + " " + x.Product.Name,
                    Quatity = x.Quantity,
                    PurchasePrice = x.PricePerUnit,
                    CreatedAt = x.CreatedAt,
                    Product = new ProductItemDto
                    {
                        Category = x.Product.Category.Name,
                        Gender = x.Product.Gender.Name,
                        CurrentPrice = x.Product.Price
                    }
                })
            }).ToList(),
            PerPage = perPage,
            TotalCount = totalCount,
        };
    }
}

