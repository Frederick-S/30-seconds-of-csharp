using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp
{
    public class Lists
    {
        public static bool All<T>(List<T> list, Predicate<T> predict)
        {
            return list.TrueForAll(predict);
        }

        public static bool Any<T>(List<T> list, Predicate<T> predicate)
        {
            return list.Exists(predicate);
        }

        public static List<List<T>> Bifurcate<T>(List<T> list, Predicate<T> predicate)
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
