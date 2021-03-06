﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirtySecondsOfCSharp.Lists
{
    public partial class Lists
    {
        public static Dictionary<TKey, TValue> MapObject<TKey, TValue>(List<TKey> list, Func<TKey, TValue> elementSelector)
        {
            return list.ToDictionary(x => x, x => elementSelector(x));
        }
    }
}
