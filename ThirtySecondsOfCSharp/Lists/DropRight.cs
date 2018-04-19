using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> DropRight<T>(List<T> list, int n)
        {
            return list.Take(list.Count - n).ToList();
        }
    }
}
