using EcommerceShop.Application;
using EcommerceShop.Application.UseCases.Commands.Brand;
using EcommerceShop.Application.UseCases.Commands.Cart;
using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Cart;
public class EfAddCartItemCommand : IAddCartItemCommand
{
    private readonly DatabaseContext _databaseContext;
    private readonly CreateCartValidator _createCartValidator;
    private readonly IApplicationActor _actor;

    public EfAddCartItemCommand(DatabaseContext databaseContext, CreateCartValidator createCartValidator, IApplicationActor actor)
    {
        _databaseContext = databaseContext;
        _createCartValidator = createCartValidator;
        _actor = actor;
    }
    public int Id => 11;

    public string Name => "Create cart command or add item to existing cart";

    public void Execute(CreateCartDto request)
    {
        request.UserId = _actor.Id;
        _createCartValidator.ValidateAndThrow(request);

        var cart = _databaseContext.Carts.Where(c => c.UserId == request.UserId && c.CartStatusId == 1).FirstOrDefault();

        if (cart == null)
        {
            cart = new Domain.Cart
            {
                UserId = _actor.Id,
                TotalPrice = 0,
                CartStatusId = 1
            };
            _databaseContext.Carts.Add(cart);
            _databaseContext.SaveChanges();
        }

        foreach (var itemDto in request.CartItems)
        {
            var productId = itemDto.ProductId;

            var existingCartItem = _databaseContext.CartItems
                .Where(ci => ci.CartId == cart.Id && ci.ProductId == productId)
                .FirstOrDefault();

            var product = _databaseContext.Products.Find(productId)!;

            var discount = _databaseContext.Discounts.FirstOrDefault(d => d.Brands.Any(db => db.BrandId == product.BrandId));

            decimal pricePerUnit = product.Price;
            if (discount != null && discount.StartAt <= DateTime.Now && discount.EndAt >= DateTime.Now)
            {
                pricePerUnit *= (1 - (discount.Percent / 100));
            }

            var quantity = itemDto.Quantity;
            decimal totalPrice = pricePerUnit * quantity; 

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
                existingCartItem.PricePerUnit = pricePerUnit;
                existingCartItem.TotalPrice = existingCartItem.Quantity * pricePerUnit;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity,
                    PricePerUnit = pricePerUnit,
                    TotalPrice = totalPrice
                };

                _databaseContext.CartItems.Add(cartItem);
            }

            cart.TotalPrice += totalPrice;
        }

        _databaseContext.SaveChanges();
    }
}
