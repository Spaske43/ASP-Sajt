using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Product;
using EcommerceShop.Application.UseCases.Queries.Product;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using EcommerceShop.Implementation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Product;
public class EfGetProductQuery : IGetProductQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfGetProductQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 27;

    public string Name => "Get all products";

    public PagedResponse<GetProductDto> Execute(ProductPagedSearch request)
    {
        var query = _databaseContext.Products.AsQueryable();

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(x => x.Name.Contains(request.Keyword) ||
                                     x.Brand.Name.Contains(request.Keyword) ||
                                     x.Category.Name.Contains(request.Keyword));
        }

        if (request.GenderId != null)
        {
            query = query.Where(x => x.GenderId == request.GenderId);
        }

        if (request.CategoryIds != null && request.CategoryIds.Any())
        {
            query = query.Where(x => request.CategoryIds.Contains(x.CategoryId));
        }

        if (request.BrandIds != null && request.BrandIds.Any())
        {
            query = query.Where(x => request.BrandIds.Contains(x.BrandId));
        }

        if (request.MinPrice.HasValue)
        {
            query = query.Where(x => x.Price >= request.MinPrice.Value);
        }
        if (request.MaxPrice.HasValue)
        {
            query = query.Where(x => x.Price <= request.MaxPrice.Value);
        }

        switch (request.OrderBy)
        {
            case "name_asc":
                query = query.OrderBy(x => x.Name);
                break;
            case "name_desc":
                query = query.OrderByDescending(x => x.Name);
                break;
            case "price_asc":
                query = query.OrderBy(x => x.Price);
                break;
            case "price_desc":
                query = query.OrderByDescending(x => x.Price);
                break;
        }

        int totalCount = query.Count();

        int perPage = request.PerPage.HasValue ? (int)Math.Abs((double)request.PerPage) : 10;
        int page = request.Page.HasValue ? (int)Math.Abs((double)request.Page) : 1;

        int skip = perPage * (page - 1);

        query = query.Skip(skip).Take(perPage);

        var productsDto = query.Select(x => new GetProductDto
        {
            Id = x.Id,
            Name = x.Brand.Name + " " + x.Name,
            Brand = x.Brand.Name,
            Category = x.Category.Name,
            Price = x.Price,
            DiscountPrice = DiscountHelper.GetDiscountedPrice(x.Price, x.Brand.Discounts.Select(x => x.Discount)),
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
        }).ToList();

        return new PagedResponse<GetProductDto>
        {
            CurrentPage = page,
            Data = productsDto,
            PerPage = perPage,
            TotalCount = totalCount,
        };
    }
}

