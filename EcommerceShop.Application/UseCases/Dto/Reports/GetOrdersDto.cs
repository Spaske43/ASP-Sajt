using EcommerceShop.Application.UseCases.Dto.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Reports;
public class GetOrdersDto : BaseEntityDto
{
    public string UserEmail { get; set; }
    public int NumberOfItems { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
    public IEnumerable<CartItemDto> Items { get; set; }
}
