using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Brand;
using EcommerceShop.Application.UseCases.Dto.Product;
using EcommerceShop.Application.UseCases.Queries.Brand;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Brand;
public class EfFindBrandQuery : IFindBrandQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfFindBrandQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 4;

    public string Name => "";

    public FindBrandDto Execute(FindRequestDto search)
    {
        var brand = _databaseContext.Brands.Find(search.Id);

        if (brand is null)
            throw new EntityNotFound("Brand record not found.");

        var mostExpensiveProduct = brand.Products.OrderByDescending(x => x.Price).FirstOrDefault();
        var bestsellingProduct = brand.Products.OrderByDescending(p => p.CartItems.Sum(ci => ci.Quantity)).FirstOrDefault();


        var response = new FindBrandDto
        {
            Id = brand.Id,
            Name = brand.Name,
            NumberOfProducts = brand.Products.Count(),
            CreatedAt = brand.CreatedAt,
            UpdatedAt = brand.UpdatedAt
        };


        if (mostExpensiveProduct is null)
        {
            response.MostExpensiveProduct = null;
        }
        else
        {
            response.MostExpensiveProduct = new FindProductDto
            {
                Id = mostExpensiveProduct.Id,
                Name = mostExpensiveProduct.Name,
                Category = mostExpensiveProduct.Category.Name,
                Gender = mostExpensiveProduct.Gender.Name,
                Price = mostExpensiveProduct.Price,
                Brand = mostExpensiveProduct.Brand.Name
            };
        }

        if(bestsellingProduct is null)
        {
            response.BestSellingProduct = null;
        }
        else
        {
            response.BestSellingProduct = new FindProductDto
            {
                Id = bestsellingProduct.Id,
                Name = bestsellingProduct.Name,
                Category = bestsellingProduct.Category.Name,
                Gender = bestsellingProduct.Gender.Name,
                Price = bestsellingProduct.Price,
                Brand = bestsellingProduct.Brand.Name
            };
        }

        return response;
    }
}
