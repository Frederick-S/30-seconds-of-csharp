using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> LongestItem<T>(params List<T>[] lists)
        {
            return lists.OrderBy(x => x.Count)
                .Last();
        }
    }
}
