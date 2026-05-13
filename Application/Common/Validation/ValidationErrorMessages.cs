namespace Application.Common.Validation
{
    /// <summary>
    /// Centralised validation error message constants used by FluentValidation validators.
    /// </summary>
    public static class ValidationErrorMessages
    {
        public const string RegularExpression    = "Special characters are not allowed in this field.";
        public const string StringLength         = "The value exceeds the allowed length limit.";
        public const string NegativeDigits       = "Negative numbers are not acceptable.";
        public const string DateTime             = "The submitted date is invalid.";
        public const string RequiredProperty     = "This field is required.";
        public const string LicencePlateFormat   = "The licence plate number format is not valid.";
        public const string NameFormat           = "The name format is not valid.";
        public const string ColorFormat          = "The colour value is not valid.";
    }
}
