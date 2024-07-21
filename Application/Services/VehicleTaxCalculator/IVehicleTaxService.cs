using Application.Commands.VehicleTaxCalculator.DTOs;

namespace Application.Services.VehicleTaxCalculator
{
    public interface IVehicleTaxService
    {
        int GetTax(int vehicleTypeId, DateTime[] dates);
        bool IsTollFreeVehicle(int VehicleTypeID);

        int GetTollFee(DateTime date, int VehicleTypeId);

        bool IsTollFreeDate(DateTime date);


    }
}
