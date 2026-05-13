namespace Application.Common.Exceptions
{
    /// <summary>
    /// Centralised error message constants used across use cases.
    /// </summary>
    public static class ErrorMessages
    {
        public const string BindDataError    = "There was a problem loading the data.";
        public const string InsertDataError  = "There is a problem registering the information.";
        public const string UpdateDataError  = "There is a problem editing the information.";
        public const string DataFormat       = "The format of the submitted information is incorrect.";
        public const string IncompleteData   = "The submitted information is incomplete.";
    }
}
