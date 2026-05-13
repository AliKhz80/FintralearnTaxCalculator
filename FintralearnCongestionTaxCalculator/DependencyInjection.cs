using Application.Commands.VehicleTaxCalculator.Handlers;
using Application.Commands.VehicleTaxCalculator.Validations;
using Application.Ports.Driven.Logging;
using Application.Ports.Driven.Persistence;
using Application.Services.TaxCalculation;
using Application.Services.VehicleTaxCalculator;
using Application.UseCases.CalculateTax;
using Infrastructure.Adapters.Logging;
using Infrastructure.Adapters.Persistence;
using Infrastructure.Adapters.Persistence.EfCore;
using MediatR.Extensions.FluentValidation.AspNetCore;

namespace FintralearnCongestionTaxCalculator
{
    /// <summary>
    /// Dependency Injection wiring for the hexagonal architecture.
    ///
    /// This class is the COMPOSITION ROOT — the only place that knows about both
    /// the Application Core (ports) and Infrastructure (adapters), and wires them
    /// together. The API project itself is just a driving adapter.
    /// </summary>
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // ── Driven Adapters: Logging ─────────────────────────────────────────
            // ILoggerPort (Application output port)  <──  NLogLoggerAdapter (Infrastructure adapter)
            services.AddSingleton<ILoggerPort, NLogLoggerAdapter>();

            // ── Driven Adapters: Persistence ────────────────────────────────────
            // IRepository output ports  <──  EF Core adapters
            services.AddScoped<IVehicleTaxRepository, VehicleTaxEfRepository>();
            services.AddScoped<IVehicleRepository,    VehicleEfRepository>();
            services.AddScoped<IPlateRepository,      PlateEfRepository>();

            // IUnitOfWork output port  <──  EF Core UnitOfWork adapter
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // ── Application Services (domain logic, lives in Application Core) ──
            services.AddTransient<ITaxCalculationService, TaxCalculationService>();
            services.AddTransient<IVehicleTaxService, VehicleTaxService>();

            // ── MediatR (Use Case dispatch — driving port wiring) ────────────────
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CalculateTaxCommandHandler).Assembly));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(VehicleTaxCalculatorCommandHandler).Assembly));

            // ── FluentValidation (pipeline behaviour) ───────────────────────────
            services.AddFluentValidation([typeof(CalculateTaxValidator).Assembly]);
            services.AddFluentValidation([typeof(VehicleTaxCalculatorValidator).Assembly]);
        }
    }
}
