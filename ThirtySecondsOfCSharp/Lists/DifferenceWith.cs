using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> DifferenceWith<T>(List<T> a, List<T> b, Func<T, T, bool> comparator)
        {
            return a.Where(x => b.FindIndex(y => comparator(x, y)) == -1)
                .ToList();
        }
    }
}