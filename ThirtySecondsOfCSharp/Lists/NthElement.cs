using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static T NthElement<T>(List<T> list, int n)
        {
            return n >= 0 ? list[n] : list[list.Count + n];
        }
    }
}
