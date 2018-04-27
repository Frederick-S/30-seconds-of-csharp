using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<object> Flatten(List<object> list, int depth = 1)
        {
            return list.SelectMany(x => x is IList && depth > 0 ? Flatten(((IList)x).Cast<object>().ToList(), depth - 1) : new List<object> { x })
                     .ToList();
        }
    }
}
