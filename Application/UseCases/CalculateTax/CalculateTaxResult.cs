namespace Application.UseCases.CalculateTax
{
    /// <summary>
    /// Output result of the "Calculate Vehicle Congestion Tax" use case.
    /// </summary>
    /// <param name="Message">Human-readable result message returned to the caller.</param>
    /// <param name="ResultCode">HTTP-style status code: 200 = success, 205 = exempt/already paid.</param>
    /// <param name="TaxAmount">Final tax amount in SEK (0 when exempt or already paid).</param>
    public sealed record CalculateTaxResult(string? Message, int ResultCode, int TaxAmount);
}
