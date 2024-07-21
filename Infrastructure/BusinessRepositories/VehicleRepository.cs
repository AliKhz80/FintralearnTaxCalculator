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
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(TaxCalculatorContext taxCalculatorContext) : base(taxCalculatorContext)
        {
        }
    }
}
