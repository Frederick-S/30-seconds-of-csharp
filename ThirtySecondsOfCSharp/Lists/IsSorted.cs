using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static int IsSorted<T>(List<T> list)
            where T : IComparable
        {
            Debug.Assert(list.Count > 1, "The list should contain at least two elements");

            var direction = list[0].CompareTo(list[1]);

            for (var i = 1; i < list.Count - 1; i++)
            {
                var result = list[i].CompareTo(list[i + 1]);

                if (result != 0 && result != direction)
                {
                    return 0;
                }
            }

            return -direction;
        }
    }
}
