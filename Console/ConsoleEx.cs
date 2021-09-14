using System;
using System.Collections.Generic;

namespace MoreEverything.Console
{
    public static class ConsoleEx
    {
        private static readonly Dictionary<Type, Func<object, object>> ParseMethods =
            new Dictionary<Type, Func<object, object>>
            {
                { typeof(int), _ => ConsoleParse.GetInt() },
                { typeof(int[]), len => ConsoleParse.GetIntArray((int)len) },
                { typeof(string), _ => System.Console.ReadLine() },
                { typeof(bool), _ => ConsoleParse.GetBool() },
            };

        // TODO: Add IRestrictions
        /// <summary>
        /// Runs a loop until the input is valid, then returns said input
        /// </summary>
        /// <param name="message">Optional message to write before the input</param>
        /// <param name="newLine">Should the input be on the same line as the optional message or on a new line</param>
        /// <param name="length">Used for arrays; sets size of input</param>
        /// <typeparam name="T">Desired type</typeparam>
        /// <returns>Desired type</returns>
        public static T GetInput<T>(string message = null, bool newLine = true, int length = 0)
        {
            if (message != null)
                if (newLine)
                    System.Console.WriteLine(message);
                else
                    System.Console.Write(message);

            var type = typeof(T);
            if (ParseMethods.ContainsKey(type))
                return (T)ParseMethods[type](length);
            throw new NotSupportedException();
        }
    }
}