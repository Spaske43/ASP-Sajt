namespace EcommerceShop.Domain;
public class Cart : Entity
{
    public decimal TotalPrice { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public int UserId { get; set; }
    public int CartStatusId { get; set; }
    public virtual User User { get; set; }
    public virtual CartStatus CartStatus { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();    
}
