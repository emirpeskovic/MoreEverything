using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public static void ForEach<TKey, TValue>(this ICollection<KeyValuePair<TKey, TValue>> collection, Action<KeyValuePair<TKey, TValue>> action)
        {
            foreach (var pair in collection)
                action.Invoke(pair);
        }

#nullable enable
        public static T? Take<T>(this ICollection<T> collection, Predicate<T> match)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var element = collection.ElementAt(i);
                if (match(element))
                {
                    collection.Remove(element);
                    return element;
                }
            }

            return default(T);
        }

        public static T[] TakeAll<T>(this ICollection<T> collection)
        {
            T[] array = new T[collection.Count];
            
            for (int i = 0; i < collection.Count; i++)
            {
                var element = collection.ElementAt(i);
                collection.Remove(element);
                array[i] = element;
            }

            return array;
        }

        public static T? FindFirst<T>(this IEnumerable<T> enumerable, Predicate<T> match)
        {
            foreach (var item in enumerable)
                if (match(item))
                    return item;

            return default(T);
        }

        public static T? FindFirst<T>(this ICollection<T> collection, Predicate<T> match)
        {
            foreach (var item in collection)
                if (match(item))
                    return item;
            return default(T);
        }

        public static T? FindOrDefault<T>(this IEnumerable<T> collection, Predicate<T> match) => FindFirst<T>(collection, match);
        public static T? FindOrDefault<T>(this ICollection<T> collection, Predicate<T> match) => FindFirst<T>(collection, match);

        public static ICollection<T> FindAllToList<T>(this ICollection<T> collection, Predicate<T> match)
        {
            ICollection<T> list = new List<T>();
            foreach (var item in collection)
                if (match(item))
                    list.Add(item);

            return list;
        }

        public static ICollection<T> FindAllToList<T>(this IEnumerable<T> enumerable, Predicate<T> match)
        {
            ICollection<T> list = new List<T>();
            foreach (var item in enumerable)
                if (match(item))
                    list.Add(item);

            return list;
        }
        #nullable disable
    }
}