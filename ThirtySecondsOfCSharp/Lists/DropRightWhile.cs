using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> DropRightWhile<T>(List<T> list, Predicate<T> predicate)
        {
            return Enumerable.Range(0, list.Count)
                .Reverse()
                .SkipWhile(i => !predicate(list[i]))
                .Reverse()
                .Select(i => list[i])
                .ToList();
        }
    }
}
