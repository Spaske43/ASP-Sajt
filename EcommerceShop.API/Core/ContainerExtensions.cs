using EcommerceShop.Application.Logging;
using EcommerceShop.Application.UseCases.Commands.Category;
using EcommerceShop.Application.UseCases.Queries.User;
using EcommerceShop.Implementation.UseCases.Commands.Category;
using EcommerceShop.Implementation.UseCases.Queries.User;
using EcommerceShop.Implementation.UseCases;
using System.IdentityModel.Tokens.Jwt;
using EcommerceShop.Application.UseCases.Commands.Brand;
using EcommerceShop.Application.UseCases.Commands.Cart;
using EcommerceShop.Application.UseCases.Commands.Discount;
using EcommerceShop.Application.UseCases.Commands.Product;
using EcommerceShop.Application.UseCases.Commands.User;
using EcommerceShop.Application.UseCases.Queries.Brand;
using EcommerceShop.Application.UseCases.Queries.Cart;
using EcommerceShop.Application.UseCases.Queries.Category;
using EcommerceShop.Application.UseCases.Queries.Discount;
using EcommerceShop.Application.UseCases.Queries.Product;
using EcommerceShop.Application.UseCases.Queries.Report;
using EcommerceShop.Implementation.UseCases.Commands.Brand;
using EcommerceShop.Implementation.UseCases.Commands.Cart;
using EcommerceShop.Implementation.UseCases.Commands.Discount;
using EcommerceShop.Implementation.UseCases.Commands.Product;
using EcommerceShop.Implementation.UseCases.Commands.User;
using EcommerceShop.Implementation.UseCases.Queries.Brand;
using EcommerceShop.Implementation.UseCases.Queries.Cart;
using EcommerceShop.Implementation.UseCases.Queries.Category;
using EcommerceShop.Implementation.UseCases.Queries.Discount;
using EcommerceShop.Implementation.UseCases.Queries.Product;
using EcommerceShop.Implementation.UseCases.Queries.Report;
using EcommerceShop.Implementation.Validators;

namespace EcommerceShop.API.Core;

public static class ContainerExtensions
{
    public static void AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<IRegistrationUserCommand, EfRegistrationUserCommand>();
        services.AddTransient<RegistrationUserValidator>();
        services.AddTransient<IEditUserCommand, EfEditUserCommand>();
        services.AddTransient<EditUserValidator>();
        services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
        services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
        services.AddTransient<IFindUserQuery, EfFindUserQuery>();
        services.AddTransient<IEditUserAccessCommand, EfEditUserAccessCommand>();
        services.AddTransient<EditUserAccessValidator>();

        //Category
        services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
        services.AddTransient<CreateCategoryValidator>();
        services.AddTransient<IFindCategoryQuery, EfFindCategoryQuery>();
        services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();

        //Products
        services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
        services.AddTransient<CreateProductValidator>();
        services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
        services.AddTransient<IEditProductCommand, EfEditProductCommand>();
        services.AddTransient<EditProductValidator>();
        services.AddTransient<IGetProductQuery, EfGetProductQuery>();
        services.AddTransient<IFindProductQuery, EfFindProductQuery>();

        //Discount
        services.AddTransient<IScheduledDiscountCommand, EfScheduledDiscountCommand>();
        services.AddTransient<ScheduleDiscountValidator>();
        services.AddTransient<IDeleteDiscountCommand, EfDeleteDiscountCommand>();
        services.AddTransient<IGetDiscountQuery, EfGetDiscountQuery>();

        //Carts
        services.AddTransient<IAddCartItemCommand, EfAddCartItemCommand>();
        services.AddTransient<CreateCartValidator>();
        services.AddTransient<IChangeCartStatusCommand, EfChangeCartStatusCommand>();
        services.AddTransient<IDeleteCartCommand, EfDeleteCartCommand>();
        services.AddTransient<IFindCartQuery, EfFindCartQuery>();
        services.AddTransient<IGetCartQuery, EfGetCartQuery>();
        services.AddTransient<IRemoveCartItemCommand, EfRemoveCartItemCommand>();

        //Report
        services.AddTransient<IGetOrdersReportQuery, EfGetOrdersReportQuery>();
        services.AddTransient<IGetUseCaseLogQuery, EfGetUseCaseLogQuery>();

        //Brands
        services.AddTransient<IGetBrandQuery, EfGetBrandQuery>();
        services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
        services.AddTransient<IFindBrandQuery, EfFindBrandQuery>();
        services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
        services.AddTransient<CreateBrandValidator>();

    }
    public static Guid? GetTokenId(this HttpRequest request)
    {
        if (request == null || !request.Headers.ContainsKey("Authorization"))
        {
            return null;
        }

        string authHeader = request.Headers["Authorization"].ToString();

        if (authHeader.Split("Bearer ").Length != 2)
        {
            return null;
        }

        string token = authHeader.Split("Bearer ")[1];

        var handler = new JwtSecurityTokenHandler();

        var tokenObj = handler.ReadJwtToken(token);

        var claims = tokenObj.Claims;

        var claim = claims.First(x => x.Type == "jti").Value;

        var tokenGuid = Guid.Parse(claim);

        return tokenGuid;
    }
}