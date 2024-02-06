using System;

namespace Oxide.Logging
{
    /// <summary>
    /// Used for sending <see cref="LogMessage"/>'s to subscribed <see cref="ILogWriter"/>'s
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="severity"></param>
        /// <param name="evt"></param>
        /// <param name="exception"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void Log(Severity severity, LogEvent evt, Exception exception, string format, params object[] args);
    }

    public interface ILogger<T> : ILogger
    {
    }
}
