﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Application.UseCases.Dto.Product;
public class CreateProductDto
{
    public string Name { get; set; }
    public string? Img { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public int GenderId { get; set; }
}
