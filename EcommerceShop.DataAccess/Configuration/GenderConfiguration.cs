using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.DataAccess.Configuration;
internal class GenderConfiguration : EntityConfiguration<Gender>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Gender> builder)
    {
        builder.Property(g => g.Id).IsRequired();
        builder.Property(g => g.Name).IsRequired();

        // Mapiranje kolekcije Products
        builder.HasMany(g => g.Products).WithOne(p => p.Gender).HasForeignKey(p => p.GenderId).IsRequired();

    }
}

