using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<List<T>> Initialize2DArray<T>(int columns, int rows, T value)
        {
            return Enumerable.Range(1, rows)
                .Select(i => Enumerable.Range(1, columns).Select(j => value).ToList())
                .ToList();
        }
    }
}
