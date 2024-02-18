﻿#if NET35
namespace System
{
    /// <summary>
    /// Defines a provider for push-based notification
    /// </summary>
    /// <typeparam name="T">The object that provides notification information</typeparam>
    public interface IObservable<out T>
    {
        /// <summary>
        /// Notifies the provider that an observer is to receive notifications
        /// </summary>
        /// <param name="observer">The object that is to receive notifications</param>
        IDisposable Subscribe(IObserver<T> observer);
    }
}
#endif
