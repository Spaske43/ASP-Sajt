using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess.Configuration;
internal class DiscountConfiguration : EntityConfiguration<Discount>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Discount> builder)
    {
        builder.Property(d => d.Id).IsRequired();
        builder.Property(d => d.Percent).IsRequired().HasColumnType("decimal(5,2)");
        builder.Property(d => d.StartAt).IsRequired();
        builder.Property(d => d.EndAt).IsRequired();

        // Mapiranje kolekcije Brands
        builder.HasMany(d => d.Brands).WithOne(db => db.Discount).HasForeignKey(db => db.DiscountId).IsRequired();
    }
}

