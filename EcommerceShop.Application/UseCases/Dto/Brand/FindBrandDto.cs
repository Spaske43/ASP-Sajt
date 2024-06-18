using EcommerceShop.Application.UseCases.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Brand;
public class FindBrandDto : BaseEntityDto
{
    public string Name { get; set; }
    public int NumberOfProducts { get; set; }
    public FindProductDto? BestSellingProduct { get; set; }
    public FindProductDto? MostExpensiveProduct { get; set; }
}