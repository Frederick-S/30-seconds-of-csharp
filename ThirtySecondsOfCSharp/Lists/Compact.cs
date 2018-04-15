using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> Compact<T>(List<T> list)
            where T : class
        {
            return list.FindAll(x => x != null).ToList();
        }
    }
}
