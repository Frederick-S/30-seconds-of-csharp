using System;
using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static bool All<T>(List<T> list, Predicate<T> predict)
        {
            return list.TrueForAll(predict);
        }
    }
}
