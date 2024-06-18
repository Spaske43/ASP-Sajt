using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.Exceptions;
public class EntityForbiddenAccess : Exception
{
    public EntityForbiddenAccess() : base("Access forbidden.") { }
    public EntityForbiddenAccess(string message) : base(message) { }
    public EntityForbiddenAccess(string message, Exception innerException) : base(message, innerException) { }
}
