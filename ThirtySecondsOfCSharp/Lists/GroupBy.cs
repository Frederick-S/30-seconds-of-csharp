using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static Dictionary<TKey, List<T>> GroupBy<T, TKey>(List<T> list, Func<T, TKey> selector)
        {
            return list.GroupBy(selector)
                .ToDictionary(x => x.Key, x => x.ToList());
        }
    }
}
