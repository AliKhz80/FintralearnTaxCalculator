namespace Domain.Enums
{
    /// <summary>
    /// Defines vehicle types that are exempt from the congestion tax.
    /// VehicleTypeId == 0 (Motorcycle) is NOT exempt; values 1–5 are exempt.
    /// </summary>
    public enum VehicleType
    {
        Motorcycle = 0,
        Tractor    = 1,
        Emergency  = 2,
        Diplomat   = 3,
        Foreign    = 4,
        Military   = 5,
    }
}
