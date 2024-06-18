using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Product;
public class ProductPagedSearch : PagedSearch
{
    public int? GenderId { get; set; }
    public List<int>? CategoryIds { get; set; }
    public List<int>? BrandIds { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? OrderBy { get; set; }
}
