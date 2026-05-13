namespace Application.Ports.Driven.Logging
{
    /// <summary>
    /// Output Port (driven port): logging contract.
    /// The Application Core defines this interface; concrete logging adapters
    /// (e.g. NLog, Serilog) are provided by the Infrastructure layer.
    /// </summary>
    public interface ILoggerPort
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogError(Exception exception);
    }
}
