using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Commands.User;
using EcommerceShop.DataAccess;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.User;
public class EfDeleteUserCommand : IDeleteUserCommand
{
    private readonly DatabaseContext _dbContext;
    public EfDeleteUserCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public int Id => 3;

    public string Name => "Delete user command.";

    public void Execute(int request)
    {

        var user = _dbContext.Users.Find(request);

        if (user is null)
            throw new EntityNotFound();

        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();

    }
}
