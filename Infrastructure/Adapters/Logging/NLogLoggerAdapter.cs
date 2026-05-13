using Application.Ports.Driven.Logging;
using NLog;

namespace Infrastructure.Adapters.Logging
{
    /// <summary>
    /// NLog implementation of the <see cref="ILoggerPort"/> output port.
    ///
    /// Hexagonal role: DRIVEN ADAPTER — adapts the NLog infrastructure library to
    /// the <see cref="ILoggerPort"/> contract defined in the Application Core.
    /// This is the correct place for NLog because it is an external dependency.
    /// </summary>
    public sealed class NLogLoggerAdapter : ILoggerPort
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => _logger.Debug(message);
        public void LogError(string message) => _logger.Error(message);
        public void LogError(Exception exception) => _logger.Error(exception);
        public void LogInfo(string message) => _logger.Info(message);
        public void LogWarn(string message) => _logger.Warn(message);
    }
}
