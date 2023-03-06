using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingApi.Auth;
using ShoppingApi.Base.Jwt;
using ShoppingApi.Data.Context;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.Repository.Concrete;
using ShoppingApi.Data.UnitOfWork.Abstract;
using ShoppingApi.Data.UnitOfWork.Concrete;
using ShoppingApi.Extension;
using ShoppingApi.Service.Abstract;
using ShoppingApi.Service.Abstract.Command;
using ShoppingApi.Service.Abstract.Query;
using ShoppingApi.Service.Concrete;
using ShoppingApi.Service.Concrete.Command;
using ShoppingApi.Service.Concrete.Query;
using ShoppingApi.Service.Mapper;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ShoppingApiDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("ShoppingApiDatabase")));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICommandCategoryService, CommandCategoryService>();
builder.Services.AddScoped<ICommandProductService, CommandProductService>();
builder.Services.AddScoped<ICommandShoppingListService, CommandShoppingListService>();
builder.Services.AddScoped<ICommandUserService, CommandUserService>();

builder.Services.AddScoped<IQueryCategoryService, QueryCategoryService>();
builder.Services.AddScoped<IQueryProductService, QueryProductService>();
builder.Services.AddScoped<IQueryShoppingListService, QueryShoppingListService>();
builder.Services.AddScoped<IQueryUserService, QueryUserService>();

builder.Services.AddScoped<ITokenManagementService, TokenManagementService>();

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // default True
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"])),
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidateAudience = false, // default True
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(2)
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomizeSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
