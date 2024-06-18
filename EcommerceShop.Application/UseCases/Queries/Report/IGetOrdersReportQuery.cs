using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Queries.Report;
public interface IGetOrdersReportQuery : IQuery<PagedResponse<GetOrdersDto>, OrderPagedSearch>
{
}
