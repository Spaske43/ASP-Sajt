using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Reports;
public class GetAuditLogDto 
{
    public int Id { get; set; }
    public string UseCaseName { get; set; }
    public string Username { get; set; }
    public string UseCaseData { get; set; }
    public DateTime ExecutedAt { get; set; }
}
