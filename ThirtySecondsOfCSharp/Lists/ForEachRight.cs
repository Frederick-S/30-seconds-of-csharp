using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static void ForEachRight<T>(List<T> list, Action<T> action)
        {
            Enumerable.Range(0, list.Count)
                .Reverse()
                .ToList()
                .ForEach(i => action(list[i]));
        }
    }
}
