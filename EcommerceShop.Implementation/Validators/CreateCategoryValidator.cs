using EcommerceShop.Application.UseCases.Dto.Category;
using EcommerceShop.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Validators;
public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    private readonly DatabaseContext _databaseContext;

    public CreateCategoryValidator(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MaximumLength(50).WithMessage("Category name must not exceed 50 characters.")
            .Must(name => !_databaseContext.Categories.Any(c => c.Name == name))
            .WithMessage("Category name already exists.");
    }
}
