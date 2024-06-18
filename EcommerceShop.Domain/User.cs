namespace EcommerceShop.Domain;
public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual ICollection<UserUseCase> UseCases { get; set; } = new List<UserUseCase>();
}