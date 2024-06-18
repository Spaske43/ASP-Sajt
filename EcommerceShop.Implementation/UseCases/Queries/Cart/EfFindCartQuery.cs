using EcommerceShop.Application;
using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.Application.UseCases.Queries.Cart;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Cart;
public class EfFindCartQuery : IFindCartQuery
{
    private readonly DatabaseContext _databaseContext;
    private readonly IApplicationActor _actor;
    public EfFindCartQuery(DatabaseContext databaseContext, IApplicationActor actor)
    {
        _databaseContext = databaseContext;
        _actor = actor;
    }
    public int Id => 21;

    public string Name => "Find cart query";

    public FindCartDto Execute(FindRequestDto search)
    {
        var cart = _databaseContext.Carts.Find(search.Id);

        if (cart is null)
            throw new EntityNotFound("Cart record not found.");

        if (cart.UserId != _actor.Id)
            throw new EntityForbiddenAccess();

        var response = new FindCartDto
        {
            Id = cart.Id,
            UserFullName = cart.User.FirstName + " " + cart.User.LastName,
            TotalPrice = cart.TotalPrice,
            Status = cart.CartStatus.Name,
            ConfirmedAt = cart.ConfirmedAt,
            CreatedAt = cart.CreatedAt,
            UpdatedAt = cart.UpdatedAt,
            Items = cart.CartItems.Select(x => new CartItemDto
            {
                Id = x.Id,
                Name = x.Product.Brand.Name + " " + x.Product.Name,
                Quatity = x.Quantity,
                PurchasePrice = x.PricePerUnit,
                CreatedAt = x.CreatedAt,
                Product = new ProductItemDto
                {
                    Category = x.Product.Category.Name,
                    Gender = x.Product.Gender.Name,
                    CurrentPrice = x.Product.Price
                }
            })
        };

        return response;
    }

}