using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> Difference<T>(List<T> a, List<T> b)
        {
            var hashSet = new HashSet<T>(b);

            return a.FindAll(x => !hashSet.Contains(x));
        }
    }
}