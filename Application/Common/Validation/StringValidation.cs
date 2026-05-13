namespace Application.Common.Validation
{
    /// <summary>
    /// Reusable regex pattern constants for input validation in the Application Core.
    /// </summary>
    public static class StringValidation
    {
        public const string NamesExpression         = "^[a-zA-Z0-9 ]*$";
        public const string AddressExpression       = "^[a-zA-Z0-9 ,]*$";
        public const string PhoneNumberExpression   = "^[0-9+]*$";
        public const string NationalCodeExpression  = "^[0-9]*$";
        public const string CommentExpression       = "^[a-zA-Z0-9 ,-]*$";
        public const string CodeExpression          = "^[0-9]*$";
        public const string SerialNumberExpression  = "^[0-9-a-zA-Z]*$";
        public const string LicencePlateExpression  = "^[0-9-a-zA-Z ]*$";
        public const string WordsExpression         = "^[a-zA-Z]*$";
    }
}
