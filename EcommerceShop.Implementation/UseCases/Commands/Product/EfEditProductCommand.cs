using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Commands.Product;
using EcommerceShop.Application.UseCases.Dto.Product;
using EcommerceShop.DataAccess;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Product;
public class EfEditProductCommand : IEditProductCommand
{
    private readonly EditProductValidator _editProductValidator;
    private readonly DatabaseContext _databaseContext;
    public EfEditProductCommand(EditProductValidator editProductValidator, DatabaseContext databaseContext)
    {
        _editProductValidator = editProductValidator;
        _databaseContext = databaseContext;
    }
    public int Id => 20;

    public string Name => "Edit product command.";

    public void Execute(EditProductDto request)
    {
        _editProductValidator.ValidateAndThrow(request);

        var product = _databaseContext.Products.Find(request.Id);

        if (product is null)
            throw new EntityNotFound();

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.CategoryId = request.CategoryId;
        product.BrandId = request.BrandId;
        product.GenderId = request.GenderId;

        _databaseContext.SaveChanges();
    }
}
