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
public class EfDeleteCartCommand : IDeleteCartCommand
{
    private readonly DatabaseContext _databaseContext;
    private readonly IApplicationActor _actor;
    public EfDeleteCartCommand(DatabaseContext databaseContext, IApplicationActor actor)
    {
        _databaseContext = databaseContext;
        _actor = actor;
    }
    public int Id => 13;

    public string Name => "Delete cart command";

    public void Execute(int request)
    {
        var cart = _databaseContext.Carts.Find(request);

        if (cart is null || cart.UserId != _actor.Id)
            throw new EntityNotFound();

        _databaseContext.Carts.Remove(cart);
        _databaseContext.SaveChanges();
    }
}
