using EcommerceShop.Application;
using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Commands.Cart;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Cart;
public class EfChangeCartStatusCommand : IChangeCartStatusCommand
{
    private readonly DatabaseContext _databaseContext;
    private readonly IApplicationActor _actor;
    public EfChangeCartStatusCommand(DatabaseContext databaseContext, IApplicationActor actor)
    {
        _actor = actor;
        _databaseContext = databaseContext;
    }
    public int Id => 14;

    public string Name => "Confirm order command.";

    public void Execute(int request)
    {
        var cart = _databaseContext.Carts.Find(request);

        if (cart is null || cart.UserId != _actor.Id)
            throw new EntityNotFound();

        cart.CartStatusId = 2;
        cart.ConfirmedAt = DateTime.UtcNow;

        _databaseContext.SaveChanges();
    }
}
