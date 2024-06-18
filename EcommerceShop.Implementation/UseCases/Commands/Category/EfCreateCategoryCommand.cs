using EcommerceShop.Application.UseCases.Commands.Category;
using EcommerceShop.Application.UseCases.Dto.Category;
using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Category;
public class EfCreateCategoryCommand : ICreateCategoryCommand
{
    private readonly CreateCategoryValidator _createCategoryValidator;
    private readonly DatabaseContext _dbContext;
    public EfCreateCategoryCommand(CreateCategoryValidator createCategoryValidator, DatabaseContext dbContext)
    {
        _createCategoryValidator = createCategoryValidator;
        _dbContext = dbContext;
    }

    public int Id => 15;

    public string Name => "Create new category command.";

    public void Execute(CreateCategoryDto request)
    {
        _createCategoryValidator.ValidateAndThrow(request);

        var category = new Domain.Category
        {
            Name = request.Name,
        };

        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }
}
