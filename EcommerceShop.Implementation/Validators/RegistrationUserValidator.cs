using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Validators;
public class RegistrationUserValidator : AbstractValidator<RegistrationUserDto>
{
    private readonly DatabaseContext _databaseContext;
    public RegistrationUserValidator(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.")
            .Matches("^[a-zA-Z]+$").WithMessage("First name can only contain letters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.")
            .Matches("^[a-zA-Z]+$").WithMessage("Last name can only contain letters.");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Must(username => !_databaseContext.Users.Any(u => u.Username == username))
            .WithMessage("Username is already registered.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Email address is not in the correct format.")
            .Must(email => !_databaseContext.Users.Any(u => u.Email == email))
            .WithMessage("Email address is already registered.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
            .Matches("^.{6,100}$").WithMessage("Password must be between 6 and 100 characters.");
    }
}
