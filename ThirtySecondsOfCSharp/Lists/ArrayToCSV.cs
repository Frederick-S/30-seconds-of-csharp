using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static string ArrayToCSV<T>(List<List<T>> list, string delimiter = ",")
        {
            return string.Join("\n", list.Select(x => string.Join(delimiter, x.Select(y => $"\"{y}\""))));
        }
    }
}
