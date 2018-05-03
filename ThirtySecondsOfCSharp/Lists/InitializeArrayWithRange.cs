using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<int> InitializeArrayWithRange(int end, int start = 0, int step = 1)
        {
            return Enumerable.Range(0, (int)Math.Ceiling((end + 1.0 - start) / step))
                .Select(i => (i * step) + start)
                .ToList();
        }
    }
}
