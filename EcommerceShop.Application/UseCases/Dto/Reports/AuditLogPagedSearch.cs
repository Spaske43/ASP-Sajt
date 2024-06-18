using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Reports;
public class AuditLogPagedSearch : PagedSearch
{
    public DateTime? StartExecutedAt { get; set; }
    public DateTime? EndExecutedAt { get; set; }
}
