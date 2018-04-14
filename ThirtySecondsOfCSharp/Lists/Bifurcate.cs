using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
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
    }
}
