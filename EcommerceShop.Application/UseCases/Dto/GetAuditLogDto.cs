﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto;
public class AuditLogDTO
{
    public int UserId { get; set; }
    public string Identity { get; set; }
    public string UseCaseName { get; set; }
    public DateTime ExecutionDateTime { get; set; }
    public bool IsAuthorized { get; set; }
    public string Data { get; set; }
}
