using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Queries.User;
public interface IGetUsersQuery : IQuery<PagedResponse<GetUserDto>, PagedSearch>
{
}
