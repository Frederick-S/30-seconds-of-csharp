using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static bool None<T>(List<T> list, Predicate<T> predicate)
        {
            return list.All(x => !predicate(x));
        }
    }
}
