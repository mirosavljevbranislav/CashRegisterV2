using Microsoft.OpenApi.Models;
using CashRegister.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CashRegister.Infrastructure.Interface;
using CashRegister.Infrastructure.Repositories;
using CashRegister.Application.Interface;
using CashRegister.Application.Services;
using FluentValidation;
using CashRegister.Domain.Models;
using CashRegister.Application.Mediatr.Handlers.ProductHandlers.QueryHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CashRegister.API", Version = "v1" });
});

builder.Services.AddDbContext<CashRegisterDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CashRegisterDBConnection")
    ));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IProductBillRepository, ProductBillRepository>();
builder.Services.AddScoped<IProductBillService, ProductBillService>();
builder.Services.AddScoped<IPriceCalculator, PriceCalculator>();
builder.Services.AddScoped<IValidator<Bill>, BillValidator>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<ProductBill>, ProductBillValidator>();
builder.Services.AddScoped<IValidationService,  ValidationService>();

builder.Services.AddValidatorsFromAssemblyContaining<BillValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductBillValidator>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetAllProductsHandler)));

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
