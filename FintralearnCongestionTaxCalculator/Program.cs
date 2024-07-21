using Domain.Models;
using FintralearnCongestionTaxCalculator;
using FintralearnCongestionTaxCalculator.Controllers;
using FintralearnCongestionTaxCalculator.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DbContext
builder.Services.AddDbContext<TaxCalculatorContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PayaneBar")));


//Adding Application Services Dependeny Injection
builder.Services.AddDependencyInjection(builder.Configuration);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapVehicleTaxCalculatorEndpoints("VehicleTaxCalculators");


app.Run();
