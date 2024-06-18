using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Discount;
public class GetDiscountDto : BaseEntityDto
{
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public decimal Percent {  get; set; }
    public string Status { get; set; }
    public IEnumerable<BrandDiscountDto> Brands { get; set; }
}


public class BrandDiscountDto : BaseEntityDto
{
    public string Name { get; set; }
    public int NumberOfProducts { get; set; }
}