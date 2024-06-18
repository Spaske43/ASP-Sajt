using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto;
public class PagedSearch : BaseSearch
{
    public int? PerPage { get; set; } = 10;
    public int? Page { get; set; } = 1;
}
