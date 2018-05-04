using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> InitializeArrayWithValues<T>(int n, T value)
        {
            return Enumerable.Range(0, n)
                .Select(i => value)
                .ToList();
        }
    }
}
