using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> Offset<T>(List<T> list, int offset)
        {
            if (offset >= 0)
            {
                return list.TakeLast(list.Count - offset)
                    .Concat(list.Take(offset))
                    .ToList();
            }
            else
            {
                return list.TakeLast(-offset)
                    .Concat(list.Take(list.Count + offset))
                    .ToList();
            }
        }
    }
}
