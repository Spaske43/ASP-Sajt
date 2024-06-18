using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Commands.User;
using EcommerceShop.Application.UseCases.Dto.User;
using EcommerceShop.DataAccess;
using EcommerceShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcommerceShop.Implementation.UseCases.Commands.User;
public class EfEditUserAccessCommand : IEditUserAccessCommand
{
    private readonly DatabaseContext _dbContext;
    private readonly EditUserAccessValidator _editUserAccessValidator;
    public EfEditUserAccessCommand(DatabaseContext dbContext, EditUserAccessValidator editUserAccessValidator)
    {
        _dbContext = dbContext;
        _editUserAccessValidator = editUserAccessValidator;
    }
    public int Id => 39;

    public string Name => "Modify user access";

    public void Execute(EditUserAccessDto request)
    {
        _editUserAccessValidator.ValidateAndThrow(request);

        var userUseCases = _dbContext.UserUseCases
                                  .Where(x => x.UserId == request.UserId)
                                  .ToList();

        _dbContext.UserUseCases.RemoveRange(userUseCases);

        _dbContext.UserUseCases.AddRange(request.UseCaseIds.Select(x =>
        new Domain.UserUseCase
        {
            UserId = request.UserId,
            UseCaseId = x
        }));

       _dbContext.SaveChanges();
    }
}
