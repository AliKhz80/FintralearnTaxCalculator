using MediatR;

namespace Application.UseCases.CalculateTax
{
    /// <summary>
    /// Input data (command) for the "Calculate Vehicle Congestion Tax" use case.
    /// Driving adapters create this object and send it through the input port.
    /// </summary>
    public sealed class CalculateTaxCommand : IRequest<CalculateTaxResult>
    {
        /// <summary>Vehicle licence plate number (3–7 alphanumeric characters).</summary>
        public string PlateNumber { get; set; } = null!;

        /// <summary>Display name of the vehicle.</summary>
        public string VehicleName { get; set; } = null!;

        /// <summary>
        /// Numeric id mapping to <see cref="Domain.Enums.VehicleType"/>.
        /// Allowed range: 0–5.
        /// </summary>
        public int VehicleTypeId { get; set; }

        /// <summary>Vehicle colour (letters only, max 20 characters).</summary>
        public string VehicleColor { get; set; } = null!;
    }
}
