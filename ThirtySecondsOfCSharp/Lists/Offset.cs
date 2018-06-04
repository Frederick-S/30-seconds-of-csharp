using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> Offset<T>(List<T> list, int n)
        {
            if (n >= 0)
            {
                return list.TakeLast(list.Count - n)
                    .Concat(list.Take(n))
                    .ToList();
            }
            else
            {
                return list.TakeLast(-n)
                    .Concat(list.Take(list.Count + n))
                    .ToList();
            }
        }
    }
}
