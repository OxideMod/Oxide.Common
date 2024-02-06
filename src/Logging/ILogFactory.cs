using System;

namespace Oxide.Logging
{
    public interface ILogFactory
    {
        /// <summary>
        /// True when nolog commandline variable is present
        /// </summary>
        bool LoggingDisabled { get; }

        /// <summary>
        /// Registers a <see cref="ILogWriter"/> with this factory
        /// </summary>
        /// <param name="writer"></param>
        void RegisterWriter(ILogWriter writer);

        /// <summary>
        /// Creates a logger for a specific type
        /// </summary>
        /// <param name="type">The parent type logging messages</param>
        /// <returns>The logger</returns>
        ILogger CreateLogger(Type type);
    }
}
