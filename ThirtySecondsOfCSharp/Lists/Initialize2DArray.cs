using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<List<T>> Initialize2DArray<T>(int width, int height, T value)
        {
            return Enumerable.Range(1, height)
                .Select(i => Enumerable.Range(1, width).Select(j => value).ToList())
                .ToList();
        }
    }
}
