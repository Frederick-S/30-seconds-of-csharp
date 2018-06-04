using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<List<T>> Partition<T>(List<T> list, Predicate<T> predicate)
        {
            return list.Aggregate(new List<List<T>> { new List<T>(), new List<T>() }, (accumulator, x) =>
            {
                var index = predicate(x) ? 0 : 1;

                accumulator[index].Add(x);

                return accumulator;
            }).ToList();
        }
    }
}
