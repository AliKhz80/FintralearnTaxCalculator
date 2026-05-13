using MediatR;


namespace Application.Commands.VehicleTaxCalculator.DTOs
{
    public class VehicleTaxCalculatorRequest : IRequest<VehicleTaxCalculatorResponse>
    {
        
        public string PlateNumber { get; set; } = null!;
        public string VehicleName { get; set; } = null!;
        
        /// <summary>
        /// VehicleTypeId should be in 0-6 range
        /// </summary>
        public int VehicleTypeID { get; set; }
        public string VehicleColor { get; set; } = null!;
    }
}
