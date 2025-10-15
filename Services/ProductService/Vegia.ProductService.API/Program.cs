using Microsoft.EntityFrameworkCore;
using Vegia.ProductService.Core.Interfaces;
using Vegia.ProductService.DAL;
using Vegia.ProductService.DAL.Contexts;

// Add this inside the Main method, after builder is created:
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDb")));

// Add Swagger
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

