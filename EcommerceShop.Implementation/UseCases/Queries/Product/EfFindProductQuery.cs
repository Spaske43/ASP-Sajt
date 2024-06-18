using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Product;
using EcommerceShop.Application.UseCases.Queries.Product;
using EcommerceShop.DataAccess;
using EcommerceShop.Implementation.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Product;
public class EfFindProductQuery : IFindProductQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfFindProductQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 28;

    public string Name => "Find product command";

    public FindProductDto Execute(FindRequestDto search)
    {
        var product = _databaseContext.Products.Find(search.Id);

        if (product is null)
            throw new EntityNotFound("Product record not found.");

        var response = new FindProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category.Name,
            Price = product.Price,
            Brand = product.Brand.Name,
            Gender = product.Gender.Name,
            Image = product.Img,
            DiscountPrice = DiscountHelper.GetDiscountedPrice(product.Price, product.Brand.Discounts.Select(x => x.Discount)),
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
        };

        return response;
    }

}
