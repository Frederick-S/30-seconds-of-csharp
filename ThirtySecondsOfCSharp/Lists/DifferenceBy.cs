using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> DifferenceBy<T>(List<T> a, List<T> b, Func<T, T> selector)
        {
            var hashSet = new HashSet<T>(b.Select(selector));

            return a.FindAll(x => !hashSet.Contains(selector(x)));
        }
    }
}