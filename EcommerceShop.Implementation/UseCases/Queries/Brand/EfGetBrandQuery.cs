using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Brand;
using EcommerceShop.Application.UseCases.Queries.Brand;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Brand;
public class EfGetBrandQuery : IGetBrandQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfGetBrandQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public int Id => 3;

    public string Name => "Get all brand.";

    public PagedResponse<GetBrandDto> Execute(PagedSearch request)
    {
        var query = _databaseContext.Brands.AsQueryable();

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(x => x.Name.Contains(request.Keyword));
        }

        int totalCount = query.Count();

        int perPage = request.PerPage.HasValue ? (int)Math.Abs((double)request.PerPage) : 10;
        int page = request.Page.HasValue ? (int)Math.Abs((double)request.Page) : 1;

        int skip = perPage * (page - 1);

        query = query.Skip(skip).Take(perPage);

        return new PagedResponse<GetBrandDto>
        {
            CurrentPage = page,
            Data = query.Select(x => new GetBrandDto
            {
                Id = x.Id,
                Name = x.Name,
                NumberOfProducts = x.Products.Count,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).ToList(),
            PerPage = perPage,
            TotalCount = totalCount,
        };
    }
}
