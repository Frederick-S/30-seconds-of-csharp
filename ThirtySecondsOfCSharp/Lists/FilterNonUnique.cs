using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> FilterNonUnique<T>(List<T> list)
        {
            return list.Where(x => list.IndexOf(x) == list.LastIndexOf(x))
                .ToList();
        }
    }
}