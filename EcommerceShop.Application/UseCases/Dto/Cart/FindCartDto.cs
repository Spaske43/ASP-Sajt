using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Cart;
public class FindCartDto : BaseEntityDto
{
    public string UserFullName {  get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
    public IEnumerable<CartItemDto> Items { get; set; }
    public DateTime? ConfirmedAt { get; set; }
}

public class CartItemDto : BaseEntityDto
{
    public string Name { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Quatity { get; set; }
    public ProductItemDto Product {  get; set; }
}

public class ProductItemDto 
{
    public string Name { get; set; }    
    public string Category { get; set; }
    public string Gender { get; set; }
    public decimal CurrentPrice {  get; set; }
}