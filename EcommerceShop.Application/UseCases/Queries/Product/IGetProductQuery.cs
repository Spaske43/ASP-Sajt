using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Queries.Product;
public interface IGetProductQuery : IQuery<PagedResponse<GetProductDto>, ProductPagedSearch>
{
}
