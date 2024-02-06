using System;

namespace Oxide.Logging
{
    [Flags]
    public enum Severity
    {
        None = 0,
        Debug = 1,
        Information = 2,
        Warning = 4,
        Error = 8,
        Stacktrace = 16,
        Chat = 32,
        Command = 64,

        Default = Information | Warning | Error | Chat | Command,
        All = Debug | Information | Warning | Error | Stacktrace | Chat | Command,
        Minimal = Error | Chat,
    }
}
