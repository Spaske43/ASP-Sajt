using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Product;
public class FindProductDto : BaseEntityDto
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Brand { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Category { get; set; }
}
