using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<List<T>> BifurcateBy<T>(List<T> list, Predicate<T> predicate)
        {
            return list.Aggregate(new List<List<T>> { new List<T>(), new List<T>() }, (accumulator, current) =>
            {
                var index = predicate.Invoke(current) ? 0 : 1;

                accumulator[index].Add(current);

                return accumulator;
            })
            .ToList();
        }
    }
}
