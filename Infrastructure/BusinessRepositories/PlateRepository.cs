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
    public class PlateRepository : Repository<Plate>, IPlateRepository
    {
        private TaxCalculatorContext taxCalculatorContext;
        public PlateRepository(TaxCalculatorContext _taxCalculatorContext) : base(_taxCalculatorContext)
        {
            taxCalculatorContext = _taxCalculatorContext; 
        }


        public async Task<Plate?> GetPlate(string Plate) => 
            await taxCalculatorContext.Plates.Include(s => s.Vehicle).FirstOrDefaultAsync(s => s.PlateNumber == Plate);
        
    }
}
