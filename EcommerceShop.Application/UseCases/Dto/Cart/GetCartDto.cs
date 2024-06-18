using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Cart;
public class GetCartDto : BaseEntityDto
{
    public string UserEmail { get; set; }
    public int NumberOfItems { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public string Status { get; set; }
}
