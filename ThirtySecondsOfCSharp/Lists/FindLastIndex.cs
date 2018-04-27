using System;
using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static int FindLastIndex<T>(List<T> list, Predicate<T> predicate)
        {
            return list.FindLastIndex(predicate);
        }
    }
}
