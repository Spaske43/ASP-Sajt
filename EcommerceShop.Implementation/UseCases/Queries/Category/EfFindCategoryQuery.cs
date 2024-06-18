using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.Category;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.Application.UseCases.Queries.Category;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.Category;
public class EfFindCategoryQuery : IFindCategoryQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfFindCategoryQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public int Id => 23;

    public string Name => "Find specific category query.";

    public FindCategoryDto Execute(FindRequestDto search)
    {
        var category = _databaseContext.Categories.Find(search.Id);

        if (category is null)
            throw new NullReferenceException("Category record not found.");

        var response = new FindCategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt,
        };

        return response;
    }
}
