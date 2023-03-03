using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data.Context;
using ShoppingApi.Data.Model;
using ShoppingApi.Data.Repository.Abstract;
using ShoppingApi.Data.Repository.Concrete;
using ShoppingApi.Data.UnitOfWork.Abstract;
using ShoppingApi.Data.UnitOfWork.Concrete;
using ShoppingApi.Service.Abstract.Command;
using ShoppingApi.Service.Abstract.Query;
using ShoppingApi.Service.Concrete.Command;
using ShoppingApi.Service.Concrete.Query;
using ShoppingApi.Service.Mapper;

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
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IGenericRepository<ShoppingList>, GenericRepository<ShoppingList>>();

builder.Services.AddScoped<ICommandCategoryService, CommandCategoryService>();
builder.Services.AddScoped<ICommandProductService, CommandProductService>();
builder.Services.AddScoped<ICommandShoppingListService, CommandShoppingListService>();

builder.Services.AddScoped<IQueryCategoryService, QueryCategoryService>();
builder.Services.AddScoped<IQueryProductService, QueryProductService>();
builder.Services.AddScoped<IQueryShoppingListService, QueryShoppingListService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
