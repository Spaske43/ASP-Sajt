using EcommerceShop.Application.UseCases.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Commands.Category;
public interface ICreateCategoryCommand : ICommand<CreateCategoryDto>
{
}
