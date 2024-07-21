using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Plate
    {
       
        public long Id { get; set; }
        [StringLength(7)]
        public string PlateNumber { get; set; } = null!;
        public long VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
    }
}
