namespace Domain.Entities
{
    /// <summary>
    /// Domain entity representing a tax payment record for a vehicle.
    /// </summary>
    public class VehicleTax
    {
        public long Id { get; set; }

        public long PlateId { get; set; }

        /// <summary>Tax amount in SEK.</summary>
        public int Tax { get; set; }

        public DateTime TaxPaidDate { get; set; }

        public Plate Plate { get; set; } = null!;
    }
}
