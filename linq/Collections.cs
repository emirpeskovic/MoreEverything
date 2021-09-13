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
    }
}