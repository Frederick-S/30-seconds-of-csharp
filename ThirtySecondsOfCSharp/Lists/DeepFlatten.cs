using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static List<object> DeepFlatten(List<object> list)
        {
            return list.SelectMany(x =>
            {
                if (x is IList)
                {
                    return DeepFlatten((x as IList).Cast<object>().ToList());
                }
                else
                {
                    return new List<object> { x };
                }
            })
            .ToList();
        }
    }
}
