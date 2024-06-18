namespace EcommerceShop.Domain;
public class DiscountBrand
{
    public int DiscountId { get; set; }
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; }
    public virtual Discount Discount { get; set; }
}
