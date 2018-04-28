using System.Collections.Generic;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static T Head<T>(List<T> list)
        {
            return list[0];
        }
    }
}
