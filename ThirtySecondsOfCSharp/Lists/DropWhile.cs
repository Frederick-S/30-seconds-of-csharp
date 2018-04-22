using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> DropWhile<T>(List<T> list, Predicate<T> predicate)
        {
            return list.SkipWhile(x => !predicate(x))
                .ToList();
        }
    }
}