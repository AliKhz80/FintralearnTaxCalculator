namespace Application.Services.TaxCalculation
{
    /// <summary>
    /// Domain service interface: encapsulates the congestion tax calculation rules.
    /// Defined in the Application Core so use cases depend on an abstraction.
    /// </summary>
    public interface ITaxCalculationService
    {
        /// <summary>
        /// Calculates the total tax for a vehicle that passed toll stations at
        /// the given <paramref name="passTimes"/>, applying the 60-minute rule
        /// and the 60 SEK daily cap.
        /// </summary>
        int GetTax(int vehicleTypeId, DateTime[] passTimes);

        /// <summary>
        /// Returns <c>true</c> if the vehicle type is exempt from the congestion tax.
        /// </summary>
        bool IsTollFreeVehicle(int vehicleTypeId);

        /// <summary>
        /// Calculates the toll fee for a single passage at the specified <paramref name="date"/>.
        /// Returns 0 for toll-free dates or exempt vehicle types.
        /// </summary>
        int GetTollFee(DateTime date, int vehicleTypeId);

        /// <summary>
        /// Returns <c>true</c> if the given date is a toll-free date
        /// (weekend, public holiday, or the day before a public holiday).
        /// </summary>
        bool IsTollFreeDate(DateTime date);
    }
}
