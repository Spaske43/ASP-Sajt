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
public class EfCreateProductCommand : ICreateProductCommand
{
    private readonly CreateProductValidator _createProductValidator;
    private readonly DatabaseContext _databaseContext;
    public EfCreateProductCommand(CreateProductValidator createProductValidator,DatabaseContext databaseContext)
    {
        _createProductValidator = createProductValidator;   
        _databaseContext = databaseContext;
    }
    public int Id => 18;

    public string Name => "Create product command.";

    public void Execute(CreateProductDto request)
    {
        _createProductValidator.ValidateAndThrow(request);

        var product = new Domain.Product
        {
            Name = request.Name,
            Img = request.Img,
            Description = request.Description,
            GenderId = request.GenderId,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId,
            Price = request.Price,
        };

        _databaseContext.Products.Add(product);
        _databaseContext.SaveChanges();
    }
}
