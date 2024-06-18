using EcommerceShop.Application.UseCases.Commands.Discount;
using EcommerceShop.Application.UseCases.Dto.Discount;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Discount;
public class EfScheduledDiscountCommand : IScheduledDiscountCommand
{
    private readonly DatabaseContext _databaseContext;
    private readonly ScheduleDiscountValidator _scheduleDiscountValidator;
    public EfScheduledDiscountCommand(DatabaseContext databaseContext, ScheduleDiscountValidator schedulerDiscountValidator)
    {
        _databaseContext = databaseContext;
        _scheduleDiscountValidator = schedulerDiscountValidator;
    }
    public int Id => 16;

    public string Name => "";

    public void Execute(ScheduleDiscountDto request)
    {
        _scheduleDiscountValidator.ValidateAndThrow(request);

        var discount = new Domain.Discount
        {
            Percent = request.Percentage,
            StartAt = request.StartAt,
            EndAt = request.EndAt
        };
        _databaseContext.Discounts.Add(discount);
        _databaseContext.SaveChanges();

        foreach (var brandId in request.BrandIds)
        {
            var discountBrand = new DiscountBrand
            {
                DiscountId = discount.Id,
                BrandId = brandId
            };
            _databaseContext.DiscountBrands.Add(discountBrand);
        }

        _databaseContext.SaveChanges();

    }
}
