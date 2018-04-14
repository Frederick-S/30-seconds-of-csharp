using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<List<T>> Chunk<T>(List<T> list, int size)
        {
            return Enumerable.Range(0, (int)Math.Ceiling(list.Count / (double)size))
                .Select(i =>
                {
                    var index = i * size;
                    var count = index + size > list.Count ? list.Count - index : size;

                    return list.GetRange(index, count);
                })
                .ToList();
        }
    }
}
