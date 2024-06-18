namespace EcommerceShop.Domain;
public class Brand : Entity
{
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<DiscountBrand> Discounts { get; set; } = new List<DiscountBrand>();
}
