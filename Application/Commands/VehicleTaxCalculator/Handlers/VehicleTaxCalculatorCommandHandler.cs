using Application.Commands.VehicleTaxCalculator.DTOs;
using Application.Extentions.AutoMapper;
using Application.Services.VehicleTaxCalculator;
using Domain;
using Domain.Models;
using MediatR;

namespace Application.Commands.VehicleTaxCalculator.Handlers
{
    public class VehicleTaxCalculatorCommandHandler : IRequestHandler<VehicleTaxCalculatorRequest, VehicleTaxCalculatorResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IVehicleTaxService vehicleTaxService;
        public VehicleTaxCalculatorCommandHandler(IUnitOfWork _unitOfWork , IVehicleTaxService _vehicleTaxService)
        {
            unitOfWork = _unitOfWork;
            vehicleTaxService = _vehicleTaxService;
        }

        public async Task<VehicleTaxCalculatorResponse> Handle(VehicleTaxCalculatorRequest request, CancellationToken cancellationToken)
        {
            if(request.VehicleTypeID != 6 && vehicleTaxService.IsTollFreeVehicle(request.VehicleTypeID))
                return new(Massage: $"vehicle {request.VehicleName} with platenumber {request.PlateNumber} is free.",
                    ResultCode: 205, TaxAmount: 0);
            // used static data but the correct one is to use datetime.Now
            if(vehicleTaxService.IsTollFreeDate(new DateTime(year: 2013, month: 01, day: 14, hour: 21, minute: 00, second: 00)))
                return new(
                    Massage: $"vehicle {request.VehicleName} with platenumber {request.PlateNumber} is free to go in HoliDates.",
                    ResultCode: 205, TaxAmount: 0);

            if(await unitOfWork.vehicleTaxesRepository.CheckVehicleTaxFullPaymentPerCurrentDay(request.PlateNumber))
                return new(
                    Massage: $"vehicle {request.VehicleName} with platenumber {request.PlateNumber} tax's has been paid.",
                    ResultCode: 205, TaxAmount: 0);

            #region Insert Vehicle
            Vehicle vehicle = new();
            vehicle.VehicleTypeId = request.VehicleTypeID;
            vehicle.Color = request.VehicleColor;
            vehicle.Name = request.VehicleName;
            #endregion
            #region Insert Plate
            Plate plate = new();
            plate.PlateNumber = request.PlateNumber;
            plate.Vehicle = vehicle;
            #endregion
            #region Insert VehicleTax
            VehicleTax vehicleTax = new();
            vehicleTax.Plate = plate;
            vehicleTax.TaxPaidDate = DateTime.Now;
            //used Static Data but the correct one is to detect date time now is a holiday or not.
            DateTime[] dateTimes = [
                new DateTime(year: 2013, month: 01, day: 14, hour: 21, minute: 00, second: 00),
                new DateTime(year: 2013, month: 01, day: 15, hour: 21, minute: 00, second: 00),
                new DateTime(year: 2013, month: 02, day: 07, hour: 06, minute: 23, second: 27),
                new DateTime(year: 2013, month: 02, day: 07, hour: 15, minute: 27, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 06, minute: 27, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 06, minute: 20, second: 27),
                new DateTime(year: 2013, month: 02, day: 08, hour: 14, minute: 35, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 15, minute: 29, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 15, minute: 47, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 16, minute: 01, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 16, minute: 48, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 17, minute: 49, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 18, minute: 29, second: 00),
                new DateTime(year: 2013, month: 02, day: 08, hour: 18, minute: 35, second: 00),
                new DateTime(year: 2013, month: 03, day: 26, hour: 14, minute: 25, second: 00),
                new DateTime(year: 2013, month: 03, day: 28, hour: 14, minute: 07, second: 27),
                
                ];

            vehicleTax.Tax = vehicleTaxService.GetTax(request.VehicleTypeID, dateTimes);
            await unitOfWork.vehicleTaxesRepository.CreateAsync(vehicleTax);
            #endregion

            await unitOfWork.CommitAsync();
            return new(Massage:$"vehicle {vehicle.Name} with platenumber {plate.PlateNumber} successfully Tax paid.", ResultCode: 200, TaxAmount: vehicleTax.Tax);
        }
    }
}
