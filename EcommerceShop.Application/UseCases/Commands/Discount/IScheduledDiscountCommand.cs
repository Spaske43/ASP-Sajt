using EcommerceShop.Application.UseCases.Dto.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Commands.Discount;
public interface IScheduledDiscountCommand : ICommand<ScheduleDiscountDto>
{
}
