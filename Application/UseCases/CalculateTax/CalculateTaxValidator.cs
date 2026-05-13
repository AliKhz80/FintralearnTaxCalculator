using Application.Common.Validation;
using Domain.Enums;
using FluentValidation;

namespace Application.UseCases.CalculateTax
{
    /// <summary>
    /// Input validation for <see cref="CalculateTaxCommand"/>.
    /// Runs automatically via the MediatR FluentValidation pipeline behaviour.
    /// </summary>
    public sealed class CalculateTaxValidator : AbstractValidator<CalculateTaxCommand>
    {
        public CalculateTaxValidator()
        {
            RuleFor(cmd => cmd.VehicleColor)
                .NotEmpty()
                    .WithMessage(ValidationErrorMessages.RequiredProperty)
                .Matches(StringValidation.WordsExpression)
                    .WithMessage(ValidationErrorMessages.RegularExpression)
                .MaximumLength(20)
                    .WithMessage(ValidationErrorMessages.StringLength);

            RuleFor(cmd => cmd.VehicleTypeId)
                .InclusiveBetween(0, (int)VehicleType.Military)
                    .WithMessage($"VehicleTypeId must be between 0 and {(int)VehicleType.Military}.");

            RuleFor(cmd => cmd.VehicleName)
                .NotEmpty()
                    .WithMessage(ValidationErrorMessages.RequiredProperty)
                .Matches(StringValidation.NamesExpression)
                    .WithMessage(ValidationErrorMessages.RegularExpression)
                .MaximumLength(50)
                    .WithMessage(ValidationErrorMessages.StringLength);

            RuleFor(cmd => cmd.PlateNumber)
                .NotEmpty()
                    .WithMessage(ValidationErrorMessages.RequiredProperty)
                .Matches(StringValidation.LicencePlateExpression)
                    .WithMessage(ValidationErrorMessages.RegularExpression)
                .Length(3, 7)
                    .WithMessage(ValidationErrorMessages.StringLength);
        }
    }
}
