using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Discount;
public class DiscountPagedSearch : PagedSearch
{
    public DateTime? StartAtMin { get; set; }
    public DateTime? StartAtMax { get; set; }
    public DateTime? EndAtMin { get; set; }
    public DateTime? EndAtMax { get; set; }
    public decimal? PercentMin { get; set; }
    public decimal? PercentMax { get; set; }
    public int? MinProducts { get; set; }
    public int? MaxProducts { get; set; }
    public bool? IsActive { get; set; }
}
