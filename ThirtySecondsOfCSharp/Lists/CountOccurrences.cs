using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static int CountOccurrences<T>(List<T> list, T value)
        {
            return list.Aggregate(0, (accumulator, current) => value.Equals(current) ? accumulator + 1 : accumulator);
        }
    }
}
