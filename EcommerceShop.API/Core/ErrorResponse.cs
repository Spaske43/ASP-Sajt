namespace EcommerceShop.API.Core;

public class ErrorResponse
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Message { get; set; }

    public string? AdditionalData { get; set; }
}
