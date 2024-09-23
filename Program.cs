using CakeShop.Repositories;
using CakeShop.Repositories.impl;
using CakeShopService.Entites;
using CakeShopService.Services;
using CakeShopService.Services.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register DbContext
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//in memory db
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("MyInMemoryDb"));

//register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Register application services
builder.Services.AddScoped<IPieService, PieService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Register repositories
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


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
