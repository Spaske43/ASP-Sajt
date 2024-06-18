using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.User;
public class GetUserDto : BaseEntityDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}
