using System;
using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static T FindLast<T>(List<T> list, Predicate<T> predicate)
        {
            return list.FindLast(predicate);
        }
    }
}
