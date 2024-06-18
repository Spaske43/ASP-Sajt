using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess.Configuration;
internal class CategoryConfiguration : EntityConfiguration<Category>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.Name).IsRequired();

        // Mapiranje kolekcije Products
        builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId).IsRequired();

    }
}

