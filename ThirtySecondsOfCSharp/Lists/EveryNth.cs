using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> EveryNth<T>(List<T> list, int nth)
        {
            return list.Where((x, i) => i % nth == nth - 1)
                .ToList();
        }
    }
}