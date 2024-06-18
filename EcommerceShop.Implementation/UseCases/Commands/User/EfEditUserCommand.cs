using BCrypt.Net;
using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Commands.User;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.DataAccess;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.User;
public class EfEditUserCommand : IEditUserCommand
{
    private readonly EditUserValidator _editUserValidator;
    private readonly DatabaseContext _dbContext;
    public EfEditUserCommand(EditUserValidator editUserValidator, DatabaseContext dbContext)
    {
        _editUserValidator = editUserValidator;
        _dbContext = dbContext;
    }
    public int Id => 2;

    public string Name => "Edit user command.";

    public void Execute(EditUserDto request)
    {
        _editUserValidator.ValidateAndThrow(request);

        var user = _dbContext.Users.Find(request.Id);

        if (user is null)
            throw new EntityNotFound();

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

        _dbContext.SaveChanges();
        
    }
}
