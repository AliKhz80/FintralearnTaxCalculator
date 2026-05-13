using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Domain entity representing a vehicle licence plate.
    /// </summary>
    public class Plate
    {
        public long Id { get; set; }

        /// <summary>Maximum 7 characters.</summary>
        [StringLength(7)]
        public string PlateNumber { get; set; } = null!;

        public long VehicleId { get; set; }

        public Vehicle Vehicle { get; set; } = null!;
    }
}
