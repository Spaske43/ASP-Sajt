using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceShop.DataAccess.Configuration;
internal class CartItemConfiguration : EntityConfiguration<CartItem>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CartItem> builder)
    {
        builder.Property(ci => ci.Id).IsRequired();
        builder.Property(ci => ci.CartId).IsRequired();
        builder.Property(ci => ci.ProductId).IsRequired();
        builder.Property(ci => ci.Quantity).IsRequired();
        builder.Property(ci => ci.PricePerUnit).IsRequired().HasColumnType("decimal(18,2)"); 
        builder.Property(ci => ci.TotalPrice).IsRequired().HasColumnType("decimal(18,2)"); 

    }
}

