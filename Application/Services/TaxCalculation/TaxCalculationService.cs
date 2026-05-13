using Domain.Enums;

namespace Application.Services.TaxCalculation
{
    /// <summary>
    /// Concrete implementation of <see cref="ITaxCalculationService"/>.
    ///
    /// Hexagonal role: this is an APPLICATION SERVICE containing domain business rules
    /// (toll schedule, holiday list, 60-minute rule, daily cap). It lives inside the
    /// Application Core because the logic itself is a use-case concern, not an external
    /// infrastructure dependency.
    /// </summary>
    public sealed class TaxCalculationService : ITaxCalculationService
    {
        /// <inheritdoc />
        public int GetTax(int vehicleTypeId, DateTime[] passTimes)
        {
            if (passTimes.Length == 0) return 0;

            DateTime intervalStart = passTimes[0];
            int totalFee = 0;

            foreach (DateTime date in passTimes)
            {
                int nextFee = GetTollFee(date, vehicleTypeId);
                int tempFee = GetTollFee(intervalStart, vehicleTypeId);

                // 60-minute rule: only charge the highest fee within any 60-minute window.
                long minutesDiff = (long)(date - intervalStart).TotalMinutes;

                if (minutesDiff <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee    += nextFee;
                    intervalStart = date;
                }
            }

            // Daily cap: maximum 60 SEK per day.
            return Math.Min(totalFee, 60);
        }

        /// <inheritdoc />
        public bool IsTollFreeVehicle(int vehicleTypeId)
        {
            // Motorcycles (id=0) are NOT exempt; all other defined types (1–5) are.
            if (vehicleTypeId == (int)VehicleType.Motorcycle) return false;
            return Enum.IsDefined(typeof(VehicleType), vehicleTypeId);
        }

        /// <inheritdoc />
        public int GetTollFee(DateTime date, int vehicleTypeId)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicleTypeId)) return 0;

            int hour   = date.Hour;
            int minute = date.Minute;

            return (hour, minute) switch
            {
                (6,  >= 0  and <= 29) => 8,
                (6,  >= 30 and <= 59) => 13,
                (7,  _)               => 18,
                (8,  >= 0  and <= 29) => 13,
                ( >= 8 and <= 14, >= 30 and <= 59) => 8,
                (15, >= 0  and <= 29) => 13,
                (15, _)               => 18,
                (16, _)               => 18,
                (17, _)               => 13,
                (18, >= 0  and <= 29) => 8,
                _                     => 0,
            };
        }

        /// <inheritdoc />
        public bool IsTollFreeDate(DateTime date)
        {
            if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) return true;

            if (date.Year == 2013)
            {
                return (date.Month, date.Day) switch
                {
                    (1,  1)              => true, // New Year's Day
                    (3,  28 or 29)       => true, // Maundy Thursday / Good Friday
                    (4,  1 or 30)        => true, // Easter Monday / Walpurgis Night
                    (5,  1 or 8 or 9)    => true, // Labour Day / Ascension / day after
                    (6,  5 or 6 or 21)   => true, // National Day + Midsummer
                    (7,  _)              => true, // Entire July
                    (11, 1)              => true, // All Saints' Day
                    (12, 24 or 25 or 26 or 31) => true, // Christmas + New Year's Eve
                    _                    => false,
                };
            }

            return false;
        }
    }
}
