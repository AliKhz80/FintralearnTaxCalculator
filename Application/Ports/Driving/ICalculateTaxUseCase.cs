using Application.UseCases.CalculateTax;
using MediatR;

namespace Application.Ports.Driver
{
    /// <summary>
    /// Input Port (driving port): entry point for the "Calculate Vehicle Tax" use case.
    /// Primary/driving adapters (e.g. HTTP Controllers, CLI) call this port.
    /// Implemented implicitly by MediatR's <see cref="IRequestHandler{TRequest,TResponse}"/>.
    /// </summary>
    public interface ICalculateTaxUseCase : IRequestHandler<CalculateTaxCommand, CalculateTaxResult>
    {
    }
}
