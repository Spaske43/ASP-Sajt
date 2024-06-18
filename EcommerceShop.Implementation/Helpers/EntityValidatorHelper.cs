using EcommerceShop.DataAccess;
using EcommerceShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Implementation.Helpers;
public class EntityValidatorHelper
{
    public static bool IsIdValid<T>(int id, DatabaseContext databaseContext) where T : Entity
    {
        return databaseContext.Set<T>().Any(e => e.Id == id);
    }
}
