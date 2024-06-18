using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Queries.Category;
public interface IGetCategoryQuery : IQuery<PagedResponse<GetCategoryDto>, PagedSearch>
{
}
