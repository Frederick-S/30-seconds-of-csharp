﻿using System;
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

        public static List<List<T>> Bifurcate<T>(List<T> list, List<bool> filter)
        {
            return Enumerable.Range(0, list.Count)
                .Aggregate(new List<List<T>> { new List<T>(), new List<T>() }, (accumulator, i) =>
                {
                    var index = filter[i] ? 0 : 1;

                    accumulator[index].Add(list[i]);

                    return accumulator;
                })
                .ToList();
        }

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
