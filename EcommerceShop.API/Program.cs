using EcommerceShop.API;
using EcommerceShop.API.Core;
using EcommerceShop.Application;
using EcommerceShop.Application.Logging;
using EcommerceShop.Application.UseCases.Commands.Brand;
using EcommerceShop.Application.UseCases.Commands.Cart;
using EcommerceShop.Application.UseCases.Commands.Category;
using EcommerceShop.Application.UseCases.Commands.Discount;
using EcommerceShop.Application.UseCases.Commands.Product;
using EcommerceShop.Application.UseCases.Commands.User;
using EcommerceShop.Application.UseCases.Queries.Brand;
using EcommerceShop.Application.UseCases.Queries.Cart;
using EcommerceShop.Application.UseCases.Queries.Category;
using EcommerceShop.Application.UseCases.Queries.Discount;
using EcommerceShop.Application.UseCases.Queries.Product;
using EcommerceShop.Application.UseCases.Queries.Report;
using EcommerceShop.Application.UseCases.Queries.User;
using EcommerceShop.DataAccess;
using EcommerceShop.Implementation;
using EcommerceShop.Implementation.Logging;
using EcommerceShop.Implementation.UseCases;
using EcommerceShop.Implementation.UseCases.Commands.Brand;
using EcommerceShop.Implementation.UseCases.Commands.Cart;
using EcommerceShop.Implementation.UseCases.Commands.Category;
using EcommerceShop.Implementation.UseCases.Commands.Discount;
using EcommerceShop.Implementation.UseCases.Commands.Product;
using EcommerceShop.Implementation.UseCases.Commands.User;
using EcommerceShop.Implementation.UseCases.Queries.Brand;
using EcommerceShop.Implementation.UseCases.Queries.Cart;
using EcommerceShop.Implementation.UseCases.Queries.Category;
using EcommerceShop.Implementation.UseCases.Queries.Discount;
using EcommerceShop.Implementation.UseCases.Queries.Product;
using EcommerceShop.Implementation.UseCases.Queries.Report;
using EcommerceShop.Implementation.UseCases.Queries.User;
using EcommerceShop.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
// Add services to the container.
var settings = new AppSettings();

builder.Configuration.Bind(settings);

builder.Services.AddSingleton(settings.Jwt);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(x => new DatabaseContext(settings.ConnectionString));
builder.Services.AddTransient<JwtTokenCreator>();

builder.Services.AddUseCases();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<DatabaseContext>();

    return new JwtApplicationActorProvider(authHeader);
});

builder.Services.AddTransient(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IApplicationActorProvider>().GetActor();
});

builder.Services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
builder.Services.AddTransient<UseCaseHandler>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = settings.Jwt.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {

            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

            if (!storage.Exists(tokenId))
            {
                context.Fail("Invalid token");
            }
            return Task.CompletedTask;

        }
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
