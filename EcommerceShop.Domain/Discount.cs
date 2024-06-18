namespace EcommerceShop.Domain;
public class Discount : Entity
{
    public decimal Percent { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public virtual ICollection<DiscountBrand> Brands { get; set; } = new List<DiscountBrand>();
}
