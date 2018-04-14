using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static Dictionary<TResult, int> CountBy<T, TResult>(List<T> list, Func<T, TResult> keySelector)
        {
            return list.GroupBy(keySelector)
                .ToDictionary(group => group.Key, group => group.Count());
        }
    }
}
