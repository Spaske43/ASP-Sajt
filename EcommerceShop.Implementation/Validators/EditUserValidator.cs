using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using EcommerceShop.Implementation.Helpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Validators;
public class EditUserValidator : AbstractValidator<EditUserDto>
{
    private readonly DatabaseContext _databaseContext;

    public EditUserValidator(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required.")
            .GreaterThan(0).WithMessage("ID must be greater than 0.")
            .Must(id => EntityValidatorHelper.IsIdValid<User>(id, _databaseContext)).WithMessage("User with the given ID does not exist.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Email address is not in the correct format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");
    }
}
