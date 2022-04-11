using CharismaShop.Services;
using CharismaShop.Repository;
using CharismaShop.Model;
using CharismaShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//Settings
IConfiguration Configuration;
//services.Configure<Settings>(Configuration);

//AutoMapper
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DbContext
services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection")));

//Services DI
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IProductService, ProductService>();

//Repositories
services.AddScoped<IRepository<Order>, OrderRepository>();
services.AddScoped<IRepository<Product>, ProductRepository>();
services.AddScoped<IRepository<Delivery>, DeliveryRepository>();

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
