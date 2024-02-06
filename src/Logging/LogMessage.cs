using System;

namespace Oxide.Logging
{
    public struct LogMessage
    {
        public Type Source { get; }

        public Severity Level { get; }

        public LogEvent Event { get; }

        public string Message { get; }

        public Exception Exception { get; }

        public DateTimeOffset Timestamp { get; }

        public LogMessage(Type source, Severity severity, LogEvent @event, string message, Exception exception)
        {
            Source = source;
            Level = severity;
            Event = @event;
            Message = message;
            Timestamp = DateTimeOffset.Now;
            Exception = exception;
        }
    }
}
