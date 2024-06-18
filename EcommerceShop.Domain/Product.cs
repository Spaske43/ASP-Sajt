namespace EcommerceShop.Domain;
public class Product : Entity
{
    public string Name { get; set; }
    public string Img { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public int GenderId { get; set; }
    public virtual Brand Brand { get; set; }
    public virtual Category Category { get; set; }
    public virtual Gender Gender { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}