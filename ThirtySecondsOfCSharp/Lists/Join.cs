using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static string Join<T>(List<T> list, string separator = ",", string endSeparator = ",")
        {
            if (separator == endSeparator)
            {
                return string.Join(separator, list);
            }
            else
            {
                return string.Join(separator, list.Take(list.Count - 1)) + string.Format("{0}{1}", endSeparator, list.Last());
            }
        }
    }
}
