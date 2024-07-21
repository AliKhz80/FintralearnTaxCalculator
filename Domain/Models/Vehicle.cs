using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models
{
    public class Vehicle
    {
       
        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(20)]
        public string Color { get; set; } = null!;
        public int VehicleTypeId { get; set; }


    }
}
