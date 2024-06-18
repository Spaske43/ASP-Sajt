using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Brand;
public class GetBrandDto : BaseEntityDto
{
    public string Name { get; set; }
    public int NumberOfProducts { get; set; }
}
