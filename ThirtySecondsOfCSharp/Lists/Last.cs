using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static T Last<T>(List<T> list)
        {
            return list.Last();
        }
    }
}
