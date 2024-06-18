using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EcommerceShop.DataAccess.Configuration;
internal class CartConfiguration : EntityConfiguration<Cart>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.TotalPrice).IsRequired().HasColumnType("decimal(18,2)"); 
        builder.Property(c => c.ConfirmedAt).IsRequired(false);
        builder.Property(c => c.UserId).IsRequired();

        builder.HasMany(c => c.CartItems).WithOne(ci => ci.Cart).HasForeignKey(ci => ci.CartId);
    }
}

