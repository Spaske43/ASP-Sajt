using EcommerceShop.Application.UseCases.Commands.User;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.DataAccess;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.User;
public class EfRegistrationUserCommand : IRegistrationUserCommand
{
    private readonly DatabaseContext _dbContext;
    private readonly RegistrationUserValidator _registrationValidator;
    private List<int> AdminUseCases =  new List<int> { 1, 2, 3, 4, 9, 10, 15, 16, 17, 18, 19, 20, 23, 24, 26, 27, 28, 30, 37, 31, 39 };
    private List<int> UserUseCases = new List<int> { 3, 4, 7, 8, 9, 10, 11, 13, 14, 21, 23, 24, 27, 28, 33, 37};
    public EfRegistrationUserCommand(DatabaseContext dbContext, RegistrationUserValidator registrationValidator)
    {
        _dbContext = dbContext;
        _registrationValidator = registrationValidator; 
    }
    public int Id => 6;

    public string Name => "Registration user command.";

    public void Execute(RegistrationUserDto request)
    {
        _registrationValidator.ValidateAndThrow(request);

        var user = new Domain.User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Username = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        if (_dbContext.Users.Any())
        {
            user.UseCases = UserUseCases.Select(id => new Domain.UserUseCase { UseCaseId = id }).ToList();
        }
        else
        {
            user.UseCases = AdminUseCases.Select(id => new Domain.UserUseCase { UseCaseId = id }).ToList();
        }


        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}
