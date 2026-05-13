using Application.Commands.VehicleTaxCalculator.DTOs;
using Application.Common.Validation;
using FluentValidation;

namespace Application.Commands.VehicleTaxCalculator.Validations
{
    public class VehicleTaxCalculatorValidator: AbstractValidator<VehicleTaxCalculatorRequest>
    {
        public VehicleTaxCalculatorValidator()
        {
            RuleFor(vehicletaxCalculatorrequest => vehicletaxCalculatorrequest.VehicleColor)
                .NotEmpty()
                .WithMessage(ValidationErrorMessages.RequiredProperty)
                .Matches(StringValidation.WordsExpression)
                .WithMessage(ValidationErrorMessages.RegularExpression)
                .MaximumLength(20)
                .WithMessage(ValidationErrorMessages.StringLength);

            RuleFor(vehicletaxCalculatorrequest => vehicletaxCalculatorrequest.VehicleTypeID)
                .NotEmpty()
                .WithMessage(ValidationErrorMessages.RequiredProperty)
                .Must(value => value <= 6)
                .WithMessage("VehicleType should be in 0-6 range!");


            RuleFor(vehicletaxCalculatorrequest => vehicletaxCalculatorrequest.VehicleName)
                .NotEmpty()
                .WithMessage(ValidationErrorMessages.RequiredProperty)
                .Matches(StringValidation.NamesExpression)
                .WithMessage(ValidationErrorMessages.RegularExpression)
                .MaximumLength(50)
                .WithMessage(ValidationErrorMessages.StringLength);


            RuleFor(vehicletaxCalculatorrequest => vehicletaxCalculatorrequest.PlateNumber)
                .NotEmpty()
                .WithMessage(ValidationErrorMessages.RequiredProperty)
                .Matches(StringValidation.LicencePlateExpression)
                .WithMessage(ValidationErrorMessages.RegularExpression)
                .MinimumLength(3)
                .WithMessage(ValidationErrorMessages.StringLength)
                .MaximumLength(7)
                .WithMessage(ValidationErrorMessages.StringLength);
        }
    }
}
