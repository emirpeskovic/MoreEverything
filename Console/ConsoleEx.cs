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