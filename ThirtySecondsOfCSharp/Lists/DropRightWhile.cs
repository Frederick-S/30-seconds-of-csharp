using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> DropRightWhile<T>(List<T> list, Predicate<T> predicate)
        {
            return list.AsEnumerable()
                .Reverse()
                .SkipWhile(x => !predicate(x))
                .Reverse()
                .ToList();
        }
    }
}
