using Domain.BusinessIRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BusinessRepositories
{
    public class VehicleTaxesRepository:Repository<VehicleTax> , IVehicleTaxesRepository
    {
        private readonly TaxCalculatorContext _taxCalculatorContext;
        public VehicleTaxesRepository(TaxCalculatorContext taxCalculatorContext):base(taxCalculatorContext)
        {
            _taxCalculatorContext = taxCalculatorContext;
        }

        public async Task<bool> CheckVehicleTaxFullPaymentPerCurrentDay(string plateNumber)
        {
            DateTime FirstofCurrentDay = DateTime.Now.Date;
            DateTime EndofCurrentDay = FirstofCurrentDay.AddDays(1);
            int VehicleTaxPaiedToday = await _taxCalculatorContext.VehicleTaxes
                .Where(s => s.Plate.PlateNumber == plateNumber && (FirstofCurrentDay <= s.TaxPaidDate && s.TaxPaidDate < EndofCurrentDay))
                .SumAsync(s => s.Tax);
            return VehicleTaxPaiedToday > 60;
                
        }
    }
}
