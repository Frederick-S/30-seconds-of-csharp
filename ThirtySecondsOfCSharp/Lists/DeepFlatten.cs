using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<object> DeepFlatten(List<object> list)
        {
            return list.SelectMany(x => x is IList ? DeepFlatten(((IList)x).Cast<object>().ToList()) : new List<object> { x })
                    .ToList();
        }
    }
}
