namespace EcommerceShop.Domain;
public class Gender : Entity
{
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
