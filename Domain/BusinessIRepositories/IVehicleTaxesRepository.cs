using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BusinessIRepositories
{
    public interface IVehicleTaxesRepository :IRepository<VehicleTax>
    {
        public Task<bool> CheckVehicleTaxFullPaymentPerCurrentDay(string plateNumber);
    }
}
