using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Product;
public class GetProductDto : BaseEntityDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
}
