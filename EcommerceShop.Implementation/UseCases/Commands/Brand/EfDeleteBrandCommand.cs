using EcommerceShop.Application.UseCases.Commands.Brand;
using EcommerceShop.DataAccess;
using EcommerceShop.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Brand;
public class EfDeleteBrandCommand : IDeleteBrandCommand
{
    private readonly DatabaseContext _databaseContext;
    public EfDeleteBrandCommand(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 2;

    public string Name => "Delete brand command";

    public void Execute(int request)
    {
        var brand = _databaseContext.Brands.Find(request);

        if (brand is null)
            throw new EntityNotFound();

        _databaseContext.Brands.Remove(brand);
        _databaseContext.SaveChanges();
    }
}
