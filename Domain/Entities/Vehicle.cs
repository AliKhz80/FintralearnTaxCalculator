namespace Domain.Entities
{
    /// <summary>
    /// Domain entity representing a vehicle.
    /// </summary>
    public class Vehicle
    {
        public long Id { get; set; }

        /// <summary>Maximum 50 characters.</summary>
        public string Name { get; set; } = null!;

        /// <summary>Maximum 20 characters.</summary>
        public string Color { get; set; } = null!;

        public int VehicleTypeId { get; set; }
    }
}
