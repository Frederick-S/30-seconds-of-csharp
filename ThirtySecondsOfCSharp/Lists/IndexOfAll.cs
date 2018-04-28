using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<int> IndexOfAll<T>(List<T> list, T value)
        {
            return Enumerable.Range(0, list.Count)
                .Where(i => list[i].Equals(value))
                .ToList();
        }
    }
}
