using System;
using System.Collections.Generic;

namespace MoreEverything.Linq
{
    public static class Collections
    {
        public static void ForEach<T>(this ICollection<T> list, Action<T> action)
        {
            foreach (var item in list)
                action.Invoke(item);
        }

        public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection, Action<KeyValuePair<TKey, TValue>> action)
        {
            foreach (var pair in collection)
                action.Invoke(pair);
        }
    }
}