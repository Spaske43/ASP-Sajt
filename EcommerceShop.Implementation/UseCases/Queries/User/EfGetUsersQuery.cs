using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.Application.UseCases.Queries.User;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.User;
public class EfGetUsersQuery : IGetUsersQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfGetUsersQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 10;

    public string Name => "Get all users.";

    public PagedResponse<GetUserDto> Execute(PagedSearch request)
    {
        var query = _databaseContext.Users.AsQueryable();

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            query = query.Where(x => x.Username.Contains(request.Keyword) ||
                                     x.Email.Contains(request.Keyword) ||
                                     x.FirstName.Contains(request.Keyword) ||
                                     x.LastName.Contains(request.Keyword));
        }

        int totalCount = query.Count();

        int perPage = request.PerPage.HasValue ? (int)Math.Abs((double)request.PerPage) : 10;
        int page = request.Page.HasValue ? (int)Math.Abs((double)request.Page) : 1;

        int skip = perPage * (page - 1);

        query = query.Skip(skip).Take(perPage);

        return new PagedResponse<GetUserDto>
        {
            CurrentPage = page,
            Data = query.Select(x => new GetUserDto
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
                Email = x.Email,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList(),
            PerPage = perPage,
            TotalCount = totalCount,
        };
    }
}
