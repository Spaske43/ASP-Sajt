using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Category;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.Application.UseCases.Queries.Category;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Category;
public class EfGetCategoryQuery : IGetCategoryQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfGetCategoryQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 24;

    public string Name => "Get all category query.";

    public PagedResponse<GetCategoryDto> Execute(PagedSearch request)
    {
        var query = _databaseContext.Categories.AsQueryable();

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(x => x.Name.Contains(request.Keyword));
        }

        int totalCount = query.Count();

        int perPage = request.PerPage.HasValue ? (int)Math.Abs((double)request.PerPage) : 10;
        int page = request.Page.HasValue ? (int)Math.Abs((double)request.Page) : 1;

        int skip = perPage * (page - 1);

        query = query.Skip(skip).Take(perPage);

        return new PagedResponse<GetCategoryDto>
        {
            CurrentPage = page,
            Data = query.Select(x => new GetCategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                NumberOfProducts = x.Products.Count,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList(),
            PerPage = perPage,
            TotalCount = totalCount,
        };
    }
}
