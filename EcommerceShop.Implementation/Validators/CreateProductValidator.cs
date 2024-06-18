using EcommerceShop.Application.UseCases.Dto.Product;
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
public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    private readonly DatabaseContext _databaseContext;
    public CreateProductValidator(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;

        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(dto => dto.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(dto => dto.BrandId)
            .Must(id => EntityValidatorHelper.IsIdValid<Brand>(id, _databaseContext)).WithMessage("Brand with the provided id does not exist.");

        RuleFor(dto => dto.CategoryId)
            .Must(id => EntityValidatorHelper.IsIdValid<Category>(id, _databaseContext)).WithMessage("Category with the provided id does not exist.");

        RuleFor(dto => dto.GenderId)
            .Must(id => EntityValidatorHelper.IsIdValid<Gender>(id, _databaseContext)).WithMessage("Gender with the provided id does not exist.");
    }
}
