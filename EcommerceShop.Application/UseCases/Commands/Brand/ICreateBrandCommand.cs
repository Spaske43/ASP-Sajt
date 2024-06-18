using EcommerceShop.Application.UseCases.Dto.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Commands.Brand;
public interface ICreateBrandCommand : ICommand<CreateBrandDto>
{
}
