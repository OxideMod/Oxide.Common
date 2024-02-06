using System;

namespace Oxide.Logging
{
    /// <summary>
    /// Used for writing <see cref="LogMessage"/>'s to a destination
    /// </summary>
    public interface ILogWriter : IDisposable
    {
        /// <summary>
        /// Called before the <see cref="ILogFactory"/> starts pushing <see cref="LogMessage"/>'s
        /// </summary>
        void BeginBatchWrite();

        /// <summary>
        /// Called by the <see cref="ILogFactory"/> when <see cref="LogMessage"/>'s are pushed
        /// </summary>
        /// <param name="message">The message to write</param>
        void HandleLogMessage(LogMessage message);

        /// <summary>
        /// Called after the <see cref="ILogFactory"/> finishes pushing <see cref="LogMessage"/>'s
        /// </summary>
        void EndBatchWrite();
    }
}
