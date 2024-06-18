using EcommerceShop.Application.UseCases.Dto.Product;
using Microsoft.AspNetCore.Http;

namespace EcommerceShop.API.Dto;

public class UploadImageDto : CreateProductDto
{
    public IFormFile Image { get; set; }

}
