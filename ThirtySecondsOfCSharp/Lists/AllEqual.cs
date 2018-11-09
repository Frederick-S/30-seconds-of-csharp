using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static bool AllEqual<T>(List<T> list)
        {
            return new HashSet<T>(list).Count <= 1;
        }
    }
}
