using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> MinN<T>(List<T> list, int n = 1)
        {
            return list.Select(x => x)
                .OrderBy(x => x)
                .Take(n)
                .ToList();
        }
    }
}
