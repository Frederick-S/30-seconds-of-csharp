using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> EveryNth<T>(List<T> list, int nth)
        {
            return Enumerable.Range(0, list.Count)
                .Where(i => i % nth == nth - 1)
                .Select(i => list[i])
                .ToList();
        }
    }
}