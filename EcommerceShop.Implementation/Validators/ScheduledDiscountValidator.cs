using EcommerceShop.Application.UseCases.Dto.Discount;
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
public class ScheduleDiscountValidator : AbstractValidator<ScheduleDiscountDto>
{
    private readonly DatabaseContext _dbContext;

    public ScheduleDiscountValidator(DatabaseContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(dto => dto.Percentage)
            .GreaterThan(0).WithMessage("Percentage must be greater than 0.");

        RuleFor(dto => dto.StartAt)
            .GreaterThan(DateTime.Now.Date).WithMessage("Start date must be after today.");

        RuleFor(dto => dto.EndAt)
            .GreaterThan(dto => dto.StartAt).WithMessage("End date must be after start date.")
            .GreaterThan(DateTime.Now.Date).WithMessage("End date must be after today.");

        RuleFor(dto => dto.BrandIds)
            .Must(brandIds => brandIds.All(id => _dbContext.Brands.Any(b => b.Id == id)))
            .WithMessage("One or more brand IDs do not exist.");
    }
 
}
