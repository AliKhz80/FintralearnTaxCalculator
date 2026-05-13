namespace Application.Common.Exceptions
{
    /// <summary>
    /// Exception for business/domain rule violations.
    /// Thrown from use cases to communicate logical errors back to driving adapters.
    /// The middleware in the API layer catches this and maps it to HTTP 400.
    /// </summary>
    public sealed class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
