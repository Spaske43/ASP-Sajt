using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Cart;
public class CreateCartDto
{
    public int UserId { get; set; }
    public List<CreateCartItemDto> CartItems { get; set; }
}

public class CreateCartItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
