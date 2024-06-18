using EcommerceShop.Application.UseCases.Commands.Cart;
using EcommerceShop.Application;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceShop.Application.Exceptions;

namespace EcommerceShop.Implementation.UseCases.Commands.Cart;
public class EfRemoveCartItemCommand : IRemoveCartItemCommand
{
    private readonly DatabaseContext _databaseContext;
    private readonly IApplicationActor _actor;

    public EfRemoveCartItemCommand(DatabaseContext databaseContext, IApplicationActor actor)
    {
        _databaseContext = databaseContext;
        _actor = actor;
    }

    public int Id => 37;

    public string Name => "Remove cart item command";

    public void Execute(int cartItemId)
    {
        var cart = _databaseContext.Carts
            .FirstOrDefault(c => c.UserId == _actor.Id && c.CartStatusId == 1);

        if (cart == null)
            throw new EntityNotFound("Record not found");

        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);

        if (cartItem == null)
            throw new EntityNotFound("Record not found");

        cart.TotalPrice -= cartItem.TotalPrice;
        _databaseContext.CartItems.Remove(cartItem);

        _databaseContext.SaveChanges();
    }
}

