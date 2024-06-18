using EcommerceShop.Application.UseCases.Dto.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Reports;
public class GetActiveDiscountDto : BaseEntityDto
{
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public float Percent { get; set; }
    public string Status { get; set; }
    public IEnumerable<BrandDiscountDto> Brands { get; set; }
}
