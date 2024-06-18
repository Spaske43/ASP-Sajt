using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess.Configuration;
internal class CartStatusConfiguration : EntityConfiguration<CartStatus>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CartStatus> builder)
    {
        builder.Property(c => c.Name).IsRequired();

        builder.HasMany(c => c.Carts).WithOne(ci => ci.CartStatus).HasForeignKey(ci => ci.CartStatusId);
    }
}
