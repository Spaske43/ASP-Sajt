using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.Application.UseCases.Dto.Reports;
using EcommerceShop.Application.UseCases.Queries.Report;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Report;
public class EfGetUseCaseLogQuery : IGetUseCaseLogQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfGetUseCaseLogQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 30;

    public string Name => "Get audit log";

    public PagedResponse<GetAuditLogDto> Execute(AuditLogPagedSearch search)
    {
        var query = _databaseContext.UseCaseLogs.AsQueryable();

        if (search.StartExecutedAt.HasValue)
        {
            query = query.Where(x => x.ExecutedAt >= search.StartExecutedAt);
        }
        if (search.EndExecutedAt.HasValue)
        {
            query = query.Where(x => x.ExecutedAt <= search.EndExecutedAt);
        }

        if (!string.IsNullOrEmpty(search.Keyword))
        {
            query = query.Where(x => x.Username.Contains(search.Keyword) ||
                                     x.UseCaseName.Contains(search.Keyword));
        }

        int totalCount = query.Count();

        int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
        int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

        int skip = perPage * (page - 1);

        query = query.Skip(skip).Take(perPage);

        return new PagedResponse<GetAuditLogDto>
        {
            CurrentPage = page,
            Data = query.Select(x => new GetAuditLogDto
            {
                Id = x.Id,
                UseCaseData = x.UseCaseData,
                UseCaseName = x.UseCaseName,
                Username = x.Username,
                ExecutedAt = x.ExecutedAt
            }).ToList(),
            PerPage = perPage,
            TotalCount = totalCount,
        };
    }
}
