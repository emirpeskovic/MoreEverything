using System;
using System.Collections;
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

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
                action.Invoke(item);
        }

        public static void ForEach<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection, Action<KeyValuePair<TKey, TValue>> action)
        {
            foreach (var pair in collection)
                action.Invoke(pair);
        }

        // TODO: doesn't work?
        // * Multiple generics mess it up
        #nullable enable
        public static T? FindFirst<G, T>(this G collection, Predicate<T> match) where G : IEnumerable<T>, IReadOnlyCollection<T>, ICollection, IEnumerable
        {
            foreach (var item in collection)
            {
                if (match.Equals(item))
                    return item;
            }

            return default(T);
        }
        #nullable disable
    }
}