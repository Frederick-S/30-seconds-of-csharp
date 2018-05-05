using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static object InitializeNDArray(object value, params int[] rows)
        {
            return rows.Length == 0 ? value : Enumerable.Repeat(InitializeNDArray(value, rows.Skip(1).ToArray()), rows[0])
                .ToList();
        }
    }
}
