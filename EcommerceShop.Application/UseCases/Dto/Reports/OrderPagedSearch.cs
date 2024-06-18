using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Reports;
public class OrderPagedSearch : PagedSearch
{
    public DateTime? StartConfirmedAt { get; set; }
    public DateTime? EndConfirmedAt { get; set; }
    public decimal? MinTotalPrice { get; set; }
    public decimal? MaxTotalPrice { get; set; }
    public int? MinItemCount { get; set; }
    public int? MaxItemCount { get; set; }
}
