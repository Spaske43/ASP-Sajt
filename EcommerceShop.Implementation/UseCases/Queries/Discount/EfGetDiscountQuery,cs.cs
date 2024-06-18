using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Discount;
using EcommerceShop.Application.UseCases.Queries.Discount;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Discount;
public class EfGetDiscountQuery : IGetDiscountQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfGetDiscountQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 26;

    public string Name => "Get all discount";

    public PagedResponse<GetDiscountDto> Execute(DiscountPagedSearch search)
    {
        var query = _databaseContext.Discounts.AsQueryable();

        if (search.StartAtMin.HasValue)
        {
            query = query.Where(x => x.StartAt >= search.StartAtMin.Value);
        }
        if (search.StartAtMax.HasValue)
        {
            query = query.Where(x => x.StartAt <= search.StartAtMax.Value);
        }
        if (search.EndAtMin.HasValue)
        {
            query = query.Where(x => x.EndAt >= search.EndAtMin.Value);
        }
        if (search.EndAtMax.HasValue)
        {
            query = query.Where(x => x.EndAt <= search.EndAtMax.Value);
        }
        if (search.PercentMin.HasValue)
        {
            query = query.Where(x => x.Percent >= search.PercentMin.Value);
        }
        if (search.PercentMax.HasValue)
        {
            query = query.Where(x => x.Percent <= search.PercentMax.Value);
        }
        if (search.MinProducts.HasValue)
        {
            query = query.Where(x => x.Brands.Any(b => b.Brand.Products.Count() >= search.MinProducts.Value));
        }
        if (search.MaxProducts.HasValue)
        {
            query = query.Where(x => x.Brands.Any(b => b.Brand.Products.Count() <= search.MaxProducts.Value));
        }
        if (search.IsActive.HasValue && search.IsActive.Value)
        {
            var now = DateTime.Now;
            query = query.Where(x => x.StartAt <= now && x.EndAt >= now);
        }

        int totalCount = query.Count();

        int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
        int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


        int skip = perPage * (page - 1);

        query = query.Skip(skip).Take(perPage);

        return new PagedResponse<GetDiscountDto>
        {
            CurrentPage = page,
            Data = query.Select(x => new GetDiscountDto
            {
                Id = x.Id,
                Percent = x.Percent,
                StartAt = x.StartAt,
                EndAt = x.EndAt,
                Brands = x.Brands.Select(x => new BrandDiscountDto
                {
                    Name = x.Brand.Name,
                    NumberOfProducts = x.Brand.Products.Count()
                }),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).ToList(),
            PerPage = perPage,
            TotalCount = totalCount,
        };
    }
}
