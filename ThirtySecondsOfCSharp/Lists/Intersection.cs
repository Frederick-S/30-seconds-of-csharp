using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> Intersection<T>(List<T> a, List<T> b)
        {
            var hashSet = new HashSet<T>(b);

            return a.Where(x => hashSet.Contains(x))
                .ToList();
        }
    }
}
