using Application.Ports.Driven.Persistence;
using Application.Ports.Driver;
using Application.Services.TaxCalculation;
using Domain.Entities;

namespace Application.UseCases.CalculateTax
{
    /// <summary>
    /// Use Case Handler: orchestrates the "Calculate Vehicle Congestion Tax" use case.
    ///
    /// Hexagonal role: implements the <see cref="ICalculateTaxUseCase"/> driving port,
    /// delegates persistence to the <see cref="IUnitOfWork"/> driven port, and uses
    /// the <see cref="ITaxCalculationService"/> domain service for business rules.
    /// </summary>
    public sealed class CalculateTaxCommandHandler : ICalculateTaxUseCase
    {
        private readonly IUnitOfWork            _unitOfWork;
        private readonly ITaxCalculationService _taxService;

        public CalculateTaxCommandHandler(IUnitOfWork unitOfWork, ITaxCalculationService taxService)
        {
            _unitOfWork = unitOfWork;
            _taxService = taxService;
        }

        public async Task<CalculateTaxResult> Handle(CalculateTaxCommand command, CancellationToken cancellationToken)
        {
            // ── Business Rule 1: toll-free vehicle? ──────────────────────────────
            // VehicleTypeId == 6 is a non-standard value kept for backward-compat.
            if (command.VehicleTypeId != 6 && _taxService.IsTollFreeVehicle(command.VehicleTypeId))
                return new(
                    Message: $"Vehicle '{command.VehicleName}' (plate: {command.PlateNumber}) is toll-free.",
                    ResultCode: 205,
                    TaxAmount: 0);

            // ── Business Rule 2: toll-free date? ─────────────────────────────────
            // NOTE: Uses static test dates. Replace with DateTime.Now for production.
            if (_taxService.IsTollFreeDate(new DateTime(2013, 01, 14, 21, 00, 00)))
                return new(
                    Message: $"Vehicle '{command.VehicleName}' (plate: {command.PlateNumber}) is exempt on this holiday.",
                    ResultCode: 205,
                    TaxAmount: 0);

            // ── Business Rule 3: daily maximum already reached? ───────────────────
            if (await _unitOfWork.VehicleTaxRepository.CheckVehicleTaxFullPaymentPerCurrentDay(command.PlateNumber))
                return new(
                    Message: $"Vehicle '{command.VehicleName}' (plate: {command.PlateNumber}) has already reached the daily tax limit.",
                    ResultCode: 205,
                    TaxAmount: 0);

            // ── Build and persist the tax record ─────────────────────────────────
            var vehicle = new Vehicle
            {
                VehicleTypeId = command.VehicleTypeId,
                Color         = command.VehicleColor,
                Name          = command.VehicleName
            };

            var plate = new Plate
            {
                PlateNumber = command.PlateNumber,
                Vehicle     = vehicle
            };

            // NOTE: Uses static test timestamps. Replace dateTimes with real passage
            //       timestamps (e.g. from an external sensor/event) in production.
            DateTime[] dateTimes =
            [
                new(2013, 01, 14, 21, 00, 00),
                new(2013, 01, 15, 21, 00, 00),
                new(2013, 02, 07, 06, 23, 27),
                new(2013, 02, 07, 15, 27, 00),
                new(2013, 02, 08, 06, 27, 00),
                new(2013, 02, 08, 06, 20, 27),
                new(2013, 02, 08, 14, 35, 00),
                new(2013, 02, 08, 15, 29, 00),
                new(2013, 02, 08, 15, 47, 00),
                new(2013, 02, 08, 16, 01, 00),
                new(2013, 02, 08, 16, 48, 00),
                new(2013, 02, 08, 17, 49, 00),
                new(2013, 02, 08, 18, 29, 00),
                new(2013, 02, 08, 18, 35, 00),
                new(2013, 03, 26, 14, 25, 00),
                new(2013, 03, 28, 14, 07, 27),
            ];

            var vehicleTax = new VehicleTax
            {
                Plate       = plate,
                TaxPaidDate = DateTime.Now,
                Tax         = _taxService.GetTax(command.VehicleTypeId, dateTimes)
            };

            await _unitOfWork.VehicleTaxRepository.CreateAsync(vehicleTax);
            await _unitOfWork.CommitAsync();

            return new(
                Message: $"Vehicle '{vehicle.Name}' (plate: {plate.PlateNumber}) — tax of {vehicleTax.Tax} SEK recorded successfully.",
                ResultCode: 200,
                TaxAmount: vehicleTax.Tax);
        }
    }
}
