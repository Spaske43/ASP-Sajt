using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Domain;
public class CartStatus : Entity
{
    public string Name { get; set; }
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
