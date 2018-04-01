using System;
using System.Collections.Generic;

namespace ThirtySecondsOfCSharp
{
    public class Lists
    {
        public static bool All<T>(List<T> list, Predicate<T> predict)
        {
            return list.TrueForAll(predict);
        }
    }
}
