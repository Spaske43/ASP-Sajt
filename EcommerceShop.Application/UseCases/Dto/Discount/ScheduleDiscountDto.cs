using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Discount;
public class ScheduleDiscountDto
{
    public decimal Percentage { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public IEnumerable<int> BrandIds { get; set; }
}
