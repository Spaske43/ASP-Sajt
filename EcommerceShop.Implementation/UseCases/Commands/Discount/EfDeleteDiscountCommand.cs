using EcommerceShop.Application.Exceptions;
using EcommerceShop.Application.UseCases.Commands.Discount;
using EcommerceShop.DataAccess;
using EcommerceShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.UseCases.Commands.Discount;
public class EfDeleteDiscountCommand : IDeleteDiscountCommand
{
    private readonly DatabaseContext _databaseContext;
    public EfDeleteDiscountCommand(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public int Id => 17;

    public string Name => "Delete discount";

    public void Execute(int request)
    {
        var discount = _databaseContext.Discounts.Find(request);

        if (discount is null)
            throw new EntityNotFound();

        _databaseContext.Discounts.Remove(discount);
        _databaseContext.SaveChanges();
    }
}
