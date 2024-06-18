using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using EcommerceShop.Implementation.Helpers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Validators;
public class CartItemValidator : AbstractValidator<CreateCartItemDto>
{
    private readonly DatabaseContext _databaseContext;

    public CartItemValidator(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;

        RuleFor(dto => dto.ProductId)
            .NotEmpty().WithMessage("ProductId is required.")
            .Must(id => EntityValidatorHelper.IsIdValid<Product>(id, _databaseContext)).WithMessage("Product with the provided id does not exist.");

        RuleFor(dto => dto.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be less than 0.");
    }
}
