using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess.Configuration;
internal class ProductConfiguration : EntityConfiguration<Product>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Img).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.BrandId).IsRequired();
        builder.Property(p => p.CategoryId).IsRequired();
        builder.Property(p => p.GenderId).IsRequired();

        // Mapiranje kolekcije CartItems
        builder.HasMany(p => p.CartItems).WithOne(ci => ci.Product).HasForeignKey(ci => ci.ProductId);

    }
}

