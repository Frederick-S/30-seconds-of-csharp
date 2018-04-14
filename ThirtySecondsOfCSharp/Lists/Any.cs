using System;
using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static bool Any<T>(List<T> list, Predicate<T> predicate)
        {
            return list.Exists(predicate);
        }
    }
}
