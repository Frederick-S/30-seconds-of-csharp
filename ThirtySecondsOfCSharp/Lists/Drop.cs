using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> Drop<T>(List<T> list, int n)
        {
            return list.Skip(n)
                .ToList();
        }
    }
}