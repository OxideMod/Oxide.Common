using System;
using Oxide.DependencyInjection;

namespace Oxide.Logging
{
    public static class LoggingExtensions
    {
        #region Dependency Injection

        public static ILogger CreateLogger<T>(this IServiceProvider provider)
        {
            return provider.GetRequiredService<ILogFactory>().CreateLogger(typeof(T));
        }

        public static IServiceProvider RegisterLogWriter(this IServiceProvider provider, ILogWriter writer)
        {
            provider.GetRequiredService<ILogFactory>().RegisterWriter(writer);
            return provider;
        }

        #endregion

        #region Factory

        public static ILogger CreateLogger<T>(this ILogFactory factory)
        {
            return factory.CreateLogger(typeof(T));
        }

        #endregion

        #region Log Helpers

        public static bool HasSeverity(this LogMessage msg, Severity severity)
        {
            return (msg.Level & severity) == severity;
        }

        public static bool HasSeverity(this Severity severity, Severity target)
        {
            return (severity & target) == target;
        }

        public static bool HasAnySeverity(this LogMessage msg, Severity severity)
        {
            if (severity.HasSeverity(Severity.Information) && msg.HasSeverity(Severity.Information))
            {
                return true;
            }

            if (severity.HasSeverity(Severity.Warning) && msg.HasSeverity(Severity.Warning))
            {
                return true;
            }

            if (severity.HasSeverity(Severity.Error) && msg.HasSeverity(Severity.Error))
            {
                return true;
            }

            if (severity.HasSeverity(Severity.Stacktrace) && msg.HasSeverity(Severity.Stacktrace))
            {
                return true;
            }

            if (severity.HasSeverity(Severity.Debug) && msg.HasSeverity(Severity.Debug))
            {
                return true;
            }

            if (severity.HasSeverity(Severity.Chat) && msg.HasSeverity(Severity.Chat))
            {
                return true;
            }

            if (severity.HasSeverity(Severity.Command) && msg.HasSeverity(Severity.Command))
            {
                return true;
            }

            return false;
        }

        public static void Log(this ILogger logger, Severity severity, string format, params object[] args)
        {
            logger.Log(severity, LogEvent.Generic, null, format, args);
        }

        public static void Information(this ILogger logger, string format, params object[] args)
        {
            logger.Log(Severity.Information, LogEvent.Generic, null, format, args);
        }

        public static void Information(this ILogger logger, LogEvent evt, string format, params object[] args)
        {
            logger.Log(Severity.Information, evt, null, format, args);
        }

        public static void Warning(this ILogger logger, string format, params object[] args)
        {
            logger.Log(Severity.Warning, LogEvent.Generic, null, format, args);
        }

        public static void Warning(this ILogger logger, LogEvent evt, string format, params object[] args)
        {
            logger.Log(Severity.Warning, evt, null, format, args);
        }

        public static void Error(this ILogger logger, string format, params object[] args)
        {
            logger.Log(Severity.Error, LogEvent.Generic, null, format, args);
        }

        public static void Error(this ILogger logger, LogEvent evt, string format, params object[] args)
        {
            logger.Log(Severity.Error, evt, null, format, args);
        }

        public static void Exception(this ILogger logger, Exception exception, string format, params object[] args)
        {
            logger.Log(Severity.Stacktrace | Severity.Error, LogEvent.Generic, exception, format, args);
        }

        public static void Exception(this ILogger logger, LogEvent evt, Exception exception, string format, params object[] args)
        {
            logger.Log(Severity.Stacktrace | Severity.Error, evt, exception, format, args);
        }

        public static void Exception(this ILogger logger, Exception exception)
        {
            logger.Log(Severity.Stacktrace | Severity.Error, LogEvent.Generic, exception, exception.Message);
        }

        public static void Exception(this ILogger logger, LogEvent evt, Exception exception)
        {
            logger.Log(Severity.Stacktrace | Severity.Error, evt, exception, exception.Message);
        }

        public static void Debug(this ILogger logger, string format, params object[] args)
        {
            logger.Log(Severity.Debug, LogEvent.Generic, null, format, args);
        }

        public static void Debug(this ILogger logger, LogEvent evt, string format, params object[] args)
        {
            logger.Log(Severity.Debug, evt, null, format, args);
        }

        #endregion
    }
}
