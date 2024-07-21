
using Application.Commands.VehicleTaxCalculator.Handlers;
using Application.Commands.VehicleTaxCalculator.Validations;
using Application.Extentions.ErrorLogger;
using Application.Services.VehicleTaxCalculator;
using Domain;
using Domain.BusinessIRepositories;
using FluentValidation;
using Infrastructure;
using Infrastructure.BusinessRepositories;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

namespace FintralearnCongestionTaxCalculator
{
    public static class  DependencyInjection 
    {
        

        public static void AddDependencyInjection (this IServiceCollection serviceCollection , IConfiguration configuration)
        {

            serviceCollection.AddSingleton<ILoggerManager, LoggerManager>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Repositories

            serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
            serviceCollection.AddScoped<IVehicleTaxesRepository, VehicleTaxesRepository>();
            serviceCollection.AddScoped<IPlateRepository, PlateRepository>();

            #endregion

            #region FluentValidation 

            serviceCollection.AddFluentValidation([typeof(VehicleTaxCalculatorValidation).Assembly]);

            #endregion

            #region Inject Mediator

            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(VehicleTaxCalculatorCommandHandler).Assembly));


            #endregion



            #region Services

            serviceCollection.AddTransient<IVehicleTaxService, VehicleTaxService>();

            #endregion

            

        }
    }
}
