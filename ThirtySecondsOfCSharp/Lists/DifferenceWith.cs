using System;
using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> DifferenceWith<T>(List<T> a, List<T> b, Func<T, T, bool> comparator)
        {
            return a.FindAll(x => b.FindIndex(y => comparator(x, y)) == -1);
        }
    }
}