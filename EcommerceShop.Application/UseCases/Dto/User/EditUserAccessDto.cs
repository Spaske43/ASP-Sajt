﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.User;

public class EditUserAccessDto
{
    public int UserId { get; set; }
    public IEnumerable<int> UseCaseIds { get; set; }
}
