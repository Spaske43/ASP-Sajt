using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.Exceptions;
using System;

public class EntityNotFound : Exception
{
    public EntityNotFound() : base("Entity not found.") { }
    public EntityNotFound(string message) : base(message) { }
    public EntityNotFound(string message, Exception innerException) : base(message, innerException) { }
    public EntityNotFound(Type entityType, object id)
        : base("Entity not found.")
    {
    }
}

