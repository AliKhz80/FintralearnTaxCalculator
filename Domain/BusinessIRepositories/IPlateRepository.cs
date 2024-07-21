using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BusinessIRepositories
{
    public interface IPlateRepository:IRepository<Plate>
    {
        public Task<Plate?> GetPlate(string Plate);
    }
}
