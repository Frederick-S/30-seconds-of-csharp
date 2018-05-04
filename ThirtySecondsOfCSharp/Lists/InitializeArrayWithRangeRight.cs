using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<int> InitializeArrayWithRangeRight(int end, int start = 0, int step = 1)
        {
            var count = (int)Math.Ceiling((end + 1.0 - start) / step);

            return Enumerable.Range(0, count)
                .Select(i => ((count - i - 1) * step) + start)
                .ToList();
        }
    }
}
