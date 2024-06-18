using EcommerceShop.Application.UseCases.Commands.Brand;
using EcommerceShop.Application.UseCases.Dto.Brand;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Brand;
public class EfCreateBrandCommand : ICreateBrandCommand
{
    private readonly DatabaseContext _databaseContext;
    private readonly CreateBrandValidator _createBrandValidator;
    public EfCreateBrandCommand(DatabaseContext databaseContext, CreateBrandValidator createBrandValidator)
    {
        _databaseContext = databaseContext;
        _createBrandValidator = createBrandValidator;
    }
    public int Id => 1;

    public string Name => "Create brand command";

    public void Execute(CreateBrandDto request)
    {
        _createBrandValidator.ValidateAndThrow(request);

        var brand = new Domain.Brand
        {
            Name = request.Name
        };

        _databaseContext.Brands.Add(brand);
        _databaseContext.SaveChanges();
    }
}
