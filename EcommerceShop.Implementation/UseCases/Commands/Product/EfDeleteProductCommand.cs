using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Commands.Product;
using EcommerceShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Product;
public class EfDeleteProductCommand : IDeleteProductCommand
{
    private readonly DatabaseContext _databaseContext;
    public EfDeleteProductCommand(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 19;

    public string Name => "Delete product command.";

    public void Execute(int request)
    {
        var product = _databaseContext.Products.Find(request);

        if (product is null)
            throw new EntityNotFound();

        _databaseContext.Products.Remove(product);
        _databaseContext.SaveChanges();
    }
}
