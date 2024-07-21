using Application.Commands.VehicleTaxCalculator.DTOs;
using Application.Extentions.ValidationAttributes;
using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.VehicleTaxCalculator.Validations
{
    public class VehicleTaxCalculatorValidation: AbstractValidator<VehicleTaxCalculatorRequest>
    {
        public VehicleTaxCalculatorValidation()
        {
            RuleFor(vehicletaxCalculatorrequest => vehicletaxCalculatorrequest.VehicleColor)
                .NotEmpty()
                .WithMessage(ValidationAttributesErrorMassages.RequiredProperty)
                .Matches(StringValidation.WordsExpression)
                .WithMessage(ValidationAttributesErrorMassages.ReqularExpression)
                .MaximumLength(20)
                .WithMessage(ValidationAttributesErrorMassages.StringLength);

            RuleFor(vehicletaxCalculatorrequest => vehicletaxCalculatorrequest.VehicleTypeID)
                .NotEmpty()
                .WithMessage(ValidationAttributesErrorMassages.RequiredProperty)
                .Must(value => value <= 6)
                .WithMessage("VehicleType should be in 0-6 range!");


            RuleFor(vehicletaxCalculatorrequest => vehicletaxCalculatorrequest.VehicleName)
                .NotEmpty()
                .WithMessage(ValidationAttributesErrorMassages.RequiredProperty)
                .Matches(StringValidation.NamesExpression)
                .WithMessage(ValidationAttributesErrorMassages.ReqularExpression)
                .MaximumLength(50)
                .WithMessage(ValidationAttributesErrorMassages.StringLength);


            RuleFor(vehicletaxCalculatorrequest => vehicletaxCalculatorrequest.PlateNumber)
                .NotEmpty()
                .WithMessage(ValidationAttributesErrorMassages.RequiredProperty)
                .Matches(StringValidation.LicencePlateExpression)
                .WithMessage(ValidationAttributesErrorMassages.ReqularExpression)
                .MinimumLength(3)
                .WithMessage(ValidationAttributesErrorMassages.StringLength)
                .MaximumLength(7)
                .WithMessage(ValidationAttributesErrorMassages.StringLength);
        }
    }
}
