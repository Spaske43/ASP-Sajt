using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Queries.Cart;
public interface IGetCartQuery : IQuery<PagedResponse<GetCartDto>, PagedSearch>
{
}
