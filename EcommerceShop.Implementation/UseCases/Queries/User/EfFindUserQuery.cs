using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Dto;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.Application.UseCases.Queries.User;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Queries.User;
public class EfFindUserQuery : IFindUserQuery
{
    private readonly DatabaseContext _databaseContext;
    public EfFindUserQuery(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public int Id => 9;

    public string Name => "Find specific user command.";

    public FindUserDto Execute(FindRequestDto search)
    {
        var user = _databaseContext.Users.Find(search.Id);

        if (user is null)
            throw new EntityNotFound("User record not found.");

        var response = new FindUserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Email = user.Email,
            NumberOfCarts = user.Carts.Count(),
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
        };

        return response;
    }

}
