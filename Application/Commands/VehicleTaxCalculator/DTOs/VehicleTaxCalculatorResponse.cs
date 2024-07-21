using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.VehicleTaxCalculator.DTOs
{
    public record VehicleTaxCalculatorResponse(string? Massage , int ResultCode , int TaxAmount);
       
}
