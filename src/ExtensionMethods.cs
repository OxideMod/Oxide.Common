using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Oxide
{
    public static class ExtensionMethods
    {
        #region Metadata

        /// <summary>
        /// Gets all <see cref="AssemblyMetadataAttribute"/> from a assembly
        /// </summary>
        /// <param name="assembly">The assembly to query for metadata</param>
        /// <returns>Array of metadata</returns>
        public static AssemblyMetadataAttribute[] Metadata(this Assembly assembly)
        {
            return Attribute.GetCustomAttributes(assembly, typeof(AssemblyMetadataAttribute), false) as AssemblyMetadataAttribute[];
        }

        /// <summary>
        /// Gets values of all <see cref="AssemblyMetadataAttribute"/> filtered by key
        /// </summary>
        /// <param name="assembly">The assembly to query for metadata</param>
        /// <param name="key">The metadata key to filter by</param>
        /// <returns>Array of metadata values</returns>
        public static string[] Metadata(this Assembly assembly, string key)
        {
            return assembly.Metadata().Where(meta => meta.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).Select(meta => meta.Value).ToArray();
        }

        #endregion

        #region Enumberables

        /// <summary>
        /// Converts a IEnumerable into a <see cref="HashSet{T}"/>
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <typeparam name="T">The collection type</typeparam>
        /// <returns>A populated <see cref="HashSet{T}"/></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection)
        {
            HashSet<T> set = new HashSet<T>();

            foreach (T item in collection)
            {
                set.Add(item);
            }

            return set;
        }

        #endregion

        #region Collections

#if NETFRAMEWORK || NETSTANDARD2_0

        // Stack<T>
        public static bool TryPop<T>(this Stack<T> stack, out T value)
        {
            if (stack.Count > 0)
            {
                value = stack.Pop();
                return true;
            }

            value = default;
            return false;
        }

        // Stack<T>
        public static bool TryPeek<T>(this Stack<T> stack, out T value)
        {
            if (stack.Count > 0)
            {
                value = stack.Peek();
                return true;
            }

            value = default;
            return false;
        }

        // Queue<T>
        public static bool TryDequeue<T>(this Queue<T> queue, out T value)
        {
            if (queue.Count > 0)
            {
                value = queue.Dequeue();
                return true;
            }

            value = default;
            return false;
        }

        // Queue<T>
        public static bool TryPeek<T>(this Queue<T> queue, out T value)
        {
            if (queue.Count > 0)
            {
                value = queue.Peek();
                return true;
            }

            value = default;
            return false;
        }

#endif

        #endregion
    }
}
