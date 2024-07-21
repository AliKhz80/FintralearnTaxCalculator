using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VehicleTax
    {
        public long Id { get; set; }
        public long PlateId { get; set; }
        public int Tax { get; set; }
        public DateTime TaxPaidDate { get; set; }
        public Plate Plate { get; set; } = null!;
    }
}
