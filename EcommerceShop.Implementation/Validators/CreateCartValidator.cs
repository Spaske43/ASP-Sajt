using EcommerceShop.Application.UseCases.Dto.Cart;
using EcommerceShop.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Validators;
public class CreateCartValidator : AbstractValidator<CreateCartDto>
{
    private readonly DatabaseContext _databaseContext;

    public CreateCartValidator(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;

        RuleFor(dto => dto.UserId).NotEmpty().WithMessage("UserId is required.");

        RuleFor(dto => dto.CartItems)
            .NotEmpty().WithMessage("CartItems cannot be empty.")
            .ForEach(item => item.SetValidator(new CartItemValidator(_databaseContext)));
    }
}
