using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<T> Initial<T>(List<T> list)
        {
            return list.Count > 1 ? list.GetRange(0, list.Count - 1) : new List<T>();
        }
    }
}
