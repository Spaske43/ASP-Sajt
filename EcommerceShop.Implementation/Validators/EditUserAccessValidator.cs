using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Validators;

public class EditUserAccessValidator : AbstractValidator<EditUserAccessDto>
{
    private static int updateUserAccessId = 39;
    public EditUserAccessValidator(DatabaseContext context)
    {
        RuleFor(x => x.UserId)
                .Must(x => context.Users.Any(u => u.Id == x))
                .WithMessage("Requested user doesn't exist.")
                .Must(x => !context.UserUseCases.Any(u => u.UseCaseId == updateUserAccessId && u.UserId == x))
                .WithMessage("Not allowed to change this user.");

        RuleFor(x => x.UseCaseIds)
            .NotEmpty().WithMessage("Parameter is required.")
            .Must(x => x.All(id => id > 0 && id <= UseCaseInfo.MaxUseCaseId)).WithMessage("Invalid usecase id range.")
            .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique usecase ids must be delivered.");
    }
}