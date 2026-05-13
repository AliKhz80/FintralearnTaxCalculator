using FintralearnCongestionTaxCalculator;
using FintralearnCongestionTaxCalculator.Controllers;
using FintralearnCongestionTaxCalculator.Middleware;
using Infrastructure.Adapters.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ── Swagger / OpenAPI ────────────────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ── EF Core DbContext (infrastructure concern — stays in composition root) ───
builder.Services.AddDbContext<TaxCalculatorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PayaneBar")));

// ── Hexagonal Architecture wiring (ports ↔ adapters) ────────────────────────
builder.Services.AddApplicationServices();

var app = builder.Build();

// ── HTTP Pipeline ────────────────────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global error handler middleware (driving adapter concern)
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

// Map all HTTP endpoints for the "VehicleTaxCalculators" driving adapter
app.MapVehicleTaxCalculatorEndpoints("VehicleTaxCalculators");

app.Run();
