using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess.Configuration;
internal class BrandConfiguration : EntityConfiguration<Brand>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(b => b.Name).IsRequired();

        builder.HasMany(b => b.Products).WithOne(p => p.Brand).HasForeignKey(p => p.BrandId).IsRequired();
        builder.HasMany(b => b.Discounts).WithOne(db => db.Brand).HasForeignKey(db => db.BrandId).IsRequired();
    }
}

