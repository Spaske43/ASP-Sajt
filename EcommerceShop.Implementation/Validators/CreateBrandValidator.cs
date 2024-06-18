using EcommerceShop.Application.UseCases.Dto.Brand;
using EcommerceShop.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Validators;
public class CreateBrandValidator : AbstractValidator<CreateBrandDto>
{
    private readonly DatabaseContext _databaseContext;
    public CreateBrandValidator(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;

        RuleFor(dto => dto.Name)
          .NotNull().WithMessage("Name must not be null.")
          .NotEmpty().WithMessage("Name must not be empty.")
          .Matches("^[a-zA-Z ]+$").WithMessage("Name must contain only letters and spaces.")
          .Must(x => !_databaseContext.Brands.Any(b => b.Name == x)).WithMessage("Brand name already exists.");
    }
}
