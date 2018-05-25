## List

### Table of Contents

<details>
<summary>View contents</summary>

* [`All`](#all)
* [`Any`](#any)
* [`Bifurcate`](#bifurcate)
* [`BifurcateBy`](#bifurcateby)
* [`Chunk`](#chunk)
* [`Compact`](#compact)
* [`CountBy`](#countby)
* [`CountOccurrences`](#countoccurrences)
* [`DeepFlatten`](#deepflatten)
* [`Difference`](#difference)
* [`DifferenceBy`](#differenceby)
* [`DifferenceWith`](#differencewith)
* [`Drop`](#drop)
* [`DropRight`](#dropright)
* [`DropRightWhile`](#droprightwhile)
* [`DropWhile`](#dropwhile)
* [`EveryNth`](#everynth)
* [`FilterNonUnique`](#filternonunique)
* [`FindLast`](#findlast)
* [`FindLastIndex`](#findlastindex)
* [`Flatten`](#flatten)
* [`ForEachRight`](#foreachright)
* [`GroupBy`](#groupby)
* [`Head`](#head)
* [`IndexOfAll`](#indexofall)
* [`Initial`](#initial)
* [`Initialize2DArray`](#initialize2darray)
* [`InitializeArrayWithRange`](#initializearraywithrange)
* [`InitializeArrayWithRangeRight`](#initializearraywithrangeright)
* [`InitializeArrayWithValues`](#initializearraywithvalues)
* [`InitializeNDArray`](#initializendarray)
* [`Intersection`](#intersection)
* [`IntersectionBy`](#intersectionby)
* [`IntersectionWith`](#intersectionwith)
* [`IsSorted`](#issorted)
* [`Join`](#join)
* [`Last`](#last)
* [`LongestItem`](#longestitem)
* [`MapObject`](#mapobject)
* [`MaxN`](#maxn)

</details>

### All
Returns `true` if the provided predicate function returns `true` for all elements in a collection, `false` otherwise.

Use `List<T>.TrueForAll(Predicate<T>)` to test if all elements in the collection return `true` based on `Predicate<T>`.

```cs
public static bool All<T>(List<T> list, Predicate<T> predict)
{
    return list.TrueForAll(predict);
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 2, 4, 6, 8, 10 };

All(numbers, x => x % 2 == 0); // true
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Any
Returns `true` if the provided predicate function returns `true` for at least one element in a collection, `false` otherwise.

Use `List<T>.Exists(Predicate<T>)` to test if any elements in the collection return `true` based on `Predicate<T>`.

```cs
public static bool Any<T>(List<T> list, Predicate<T> predicate)
{
    return list.Exists(predicate);
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 30 };

Any(numbers, x => x > 10); // true
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Bifurcate
Splits values into two groups. If an element in `filter` is truthy, the corresponding element in the collection belongs to the first group; otherwise, it belongs to the second group.

Use `Enumerable.Aggregate<TSource, TAccumulate>(IEnumerable<TSource>, TAccumulate, Func<TAccumulate, TSource, TAccumulate>)` and `List<T>.Add(T)` to add elements to groups, based on `filter`.

```cs
public static List<List<T>> Bifurcate<T>(List<T> list, List<bool> filter)
{
    return Enumerable.Range(0, list.Count)
        .Aggregate(new List<List<T>> { new List<T>(), new List<T>() }, (accumulator, i) =>
        {
            var index = filter[i] ? 0 : 1;

            accumulator[index].Add(list[index]);

            return accumulator;
        })
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
var filter = new List<bool> { true, true, true, false, false, false };

Bifurcate(numbers, filter); // { { 1, 2, 3 }, { 4, 5, 6 } }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### BifurcateBy
Splits values into two groups according to a predicate function, which specifies which group an element in the input collection belongs to. If the predicate function returns a truthy value, the collection element belongs to the first group; otherwise, it belongs to the second group.

Use `Enumerable.Aggregate<TSource, TAccumulate>(IEnumerable<TSource>, TAccumulate, Func<TAccumulate, TSource, TAccumulate>)` and `List<T>.Add(T)` to add elements to groups, based on the value returned by `Predicate<T>` for each element.

```cs
public static List<List<T>> BifurcateBy<T>(List<T> list, Predicate<T> predicate)
{
    return list.Aggregate(new List<List<T>> { new List<T>(), new List<T>() }, (accumulator, current) =>
    {
        var index = predicate.Invoke(current) ? 0 : 1;

        accumulator[index].Add(current);

        return accumulator;
    })
    .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

BifurcateBy(numbers, x => x % 2 == 0); // { { 2, 4, 6 }, { 1, 3, 5 } }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Chunk
Chunks an list into smaller lists of a specified size.

Use `Enumerable.Range(Int32, Int32)` to create a new list, that fits the number of chunks that will be produced. Use `List<T>.GetRange(Int32, Int32)` to map each element of the new list to a chunk the length of `size`. If the original list can't be split evenly, the final chunk will contain the remaining elements.

```cs
public static List<List<T>> Chunk<T>(List<T> list, int size)
{
    return Enumerable.Range(0, (int)Math.Ceiling(list.Count / (double)size))
        .Select(i =>
        {
            var index = i * size;
            var count = index + size > list.Count ? list.Count - index : size;

            return list.GetRange(index, count);
        })
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4, 5 };

Chunk(numbers, 2); // { { 1, 2 }, { 3, 4 }, { 5 } }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Compact
Removes null values from a list.

Use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` to filter out null values.

```cs
public static List<T> Compact<T>(List<T> list)
    where T : class
{
    return list.Where(x => x != null)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var list = new List<string> { "a", null, "c", null };

Compact(list); // { "a", "c" }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### CountBy
Groups the elements of a list based on the given function and returns the count of elements in each group.

Use `Enumerable.GroupBy<TSource, TKey>(IEnumerable<TSource>, Func<TSource, TKey>)` to group the elements of the list according to the specified key selector function `Func<TSource, TKey>`. Use `Enumerable.ToDictionary<TSource, TKey, TElement>(IEnumerable<TSource>, Func<TSource, TKey>, Func<TSource, TElement>)` to create a dictionary, where the keys are produced from the mapped results.

```cs
public static Dictionary<TResult, int> CountBy<T, TResult>(List<T> list, Func<T, TResult> keySelector)
{
    return list.GroupBy(keySelector)
        .ToDictionary(group => group.Key, group => group.Count());
}
```

<details>
<summary>Examples</summary>

```cs
var strings = new List<string> { "one", "two", "three" };

CountBy(strings, x => x.Length); // { 3: 2, 5: 1 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### CountOccurrences
Counts the occurrences of a value in a list.

Use `Enumerable.Aggregate<TSource, TAccumulate>(IEnumerable<TSource>, TAccumulate, Func<TAccumulate, TSource, TAccumulate>)` to increment a counter each time you encounter the specific value inside the list.

```cs
public static int CountOccurrences<T>(List<T> list, T value)
{
    return list.Aggregate(0, (accumulator, current) => value.Equals(current) ? accumulator + 1 : accumulator);
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 1, 2, 1, 2, 3 };

CountOccurrences(numbers, 1); // 3
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### DeepFlatten
Deep flattens a list.

Use recursion. Use `Enumerable.SelectMany<TSource, TResult>(IEnumerable<TSource>, Func<TSource, IEnumerable<TResult>>)` to flatten a list. Recursively flatten each element that is a list.

```cs
public static List<object> DeepFlatten(List<object> list)
{
    return list.SelectMany(x => x is IList ? DeepFlatten(((IList)x).Cast<object>().ToList()) : new List<object> { x })
            .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<object>
{
    1,
    new List<int> { 2 },
    new List<object>
    {
        new List<int> { 3 },
        4,
    },
    5,
};

DeepFlatten(numbers); // { 1, 2, 3, 4, 5 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Difference
Returns the difference between two lists.

Create a `HashSet<T>` from `b`, then use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` on `a` to only keep values not contained in `b`.

```cs
public static List<T> Difference<T>(List<T> a, List<T> b)
{
    var hashSet = new HashSet<T>(b);

    return a.Where(x => !hashSet.Contains(x))
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var a = new List<int> { 1, 2, 3 };
var b = new List<int> { 1, 2, 4 };

Difference(a, b); // { 3 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### DifferenceBy
Returns the difference between two lists, after applying the provided function to each list element of both.

Create a `HashSet<T>` by applying `selector` to each element in `b`, then use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` in combination with `selector` on `a` to only keep values not contained in the previously created `HashSet<T>`.

```cs
public static List<T> DifferenceBy<T>(List<T> a, List<T> b, Func<T, T> selector)
{
    var hashSet = new HashSet<T>(b.Select(selector));

    return a.Where(x => !hashSet.Contains(selector(x)))
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var a = new List<double> { 2.1, 1.2 };
var b = new List<double> { 2.3, 3.4 };

DifferenceBy(a, b, Math.Floor); // { 1.2 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### DifferenceWith
Filters out all values from a list for which the comparator function does not return `true`.

Use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` and `List<T>.FindIndex(Predicate<T>)` to find the appropriate values.

```cs
public static List<T> DifferenceWith<T>(List<T> a, List<T> b, Func<T, T, bool> comparator)
{
    return a.Where(x => b.FindIndex(y => comparator(x, y)) == -1)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var a = new List<double> { 1, 1.2, 1.5, 3, 0 };
var b = new List<double> { 1.9, 3, 0 };

DifferenceWith(a, b, (x, y) => Math.Round(x) == Math.Round(y)); // { 1, 1.2 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Drop
Returns a new list with `n` elements removed from the left.

Use `Enumerable.Skip(IEnumerable<TSource>, Int32)` to remove the specified number of elements from the left.

```cs
public static List<T> Drop<T>(List<T> list, int n)
{
    return list.Skip(n)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3 };

Drop(numbers, 2); // { 3 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### DropRight
Returns a new list with `n` elements removed from the right.

Use `Enumerable.Take(IEnumerable<TSource>, Int32)`to remove the specified number of elements from the right.

```cs
public static List<T> DropRight<T>(List<T> list, int n)
{
    return list.Take(list.Count - n)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3 };

DropRight(numbers, 2); // { 1 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### DropRightWhile
Removes elements from the end of a list until the passed function returns `true`. Returns the remaining elements in the list.

Reverse the list, using `Enumerable.SkipWhile<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` to skip the elements of the list until the returned value from the function is `true`. Reverse and returns the remaining elements.

```cs
public static List<T> DropRightWhile<T>(List<T> list, Predicate<T> predicate)
{
    return list.AsEnumerable()
        .Reverse()
        .SkipWhile(x => !predicate(x))
        .Reverse()
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4 };

DropRightWhile(numbers, x => x < 3); // { 1, 2 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### DropWhile
Removes elements in a list until the passed function returns `true`. Returns the remaining elements in the list.

Using `Enumerable.SkipWhile<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` to skip the elements of the list until the returned value from the function is `true`. Returns the remaining elements.

```cs
public static List<T> DropWhile<T>(List<T> list, Predicate<T> predicate)
{
    return list.SkipWhile(x => !predicate(x))
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4 };

DropWhile(numbers, x => x >= 3)); // { 3, 4 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### EveryNth
Returns every nth element in a list.

Use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Int32, Boolean>)` to create a new list that contains every nth element of a given list.

```cs
public static List<T> EveryNth<T>(List<T> list, int nth)
{
    return list.Where((x, i) => i % nth == nth - 1)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

EveryNth(numbers, 2); // { 2, 4, 6 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### FilterNonUnique
Filters out the non-unique values in a list.

Use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` for a list containing only the unique values.

```cs
public static List<T> FilterNonUnique<T>(List<T> list)
{
    return list.Where(x => list.IndexOf(x) == list.LastIndexOf(x))
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };

FilterNonUnique(numbers); // { 1, 3, 5 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### FindLast
Returns the last element for which the provided function returns a truthy value.

Use `List<T>.FindLast(Predicate<T>)` to get the last one.

```cs
public static T FindLast<T>(List<T> list, Predicate<T> predicate)
{
    return list.FindLast(predicate);
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4 };

FindLast(numbers, x => x % 2 == 1)); // 3
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### FindLastIndex
Returns the index of the last element for which the provided function returns a truthy value.

Use `List<T>.FindLastIndex(Predicate<T>)` to get the last one.

```cs
public static int FindLastIndex<T>(List<T> list, Predicate<T> predicate)
{
    return list.FindLastIndex(predicate);
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4 };

FindLastIndex(numbers, x => x % 2 == 1)); // 2
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Flatten
Flattens a list up to the specified depth.

Use recursion. Use `Enumerable.SelectMany<TSource, TResult>(IEnumerable<TSource>, Func<TSource, IEnumerable<TResult>>)` to flatten a list. Recursively flatten each element that is a list and check depth.

```cs
public static List<object> Flatten(List<object> list, int depth = 1)
{
    return list.SelectMany(x => x is IList && depth > 0 ? Flatten(((IList)x).Cast<object>().ToList(), depth - 1) : new List<object> { x })
             .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var list = new List<object>
{
    1,
    new List<object>
    {
        2,
        new List<object>
        {
            3,
            new List<object> { 4, 5 },
            6,
        },
        7,
    },
    8,
};

Flatten(list, 2); // { 1, 2, 3, { 4, 5 }, 6, 7, 8 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### ForEachRight
Executes a provided function once for each list element, starting from the list's last element.

Use `Enumerable.Range(Int32, Int32)` to create an `int` sequence, `Enumerable.Reverse(IEnumerable<TSource>)` to reverse it and `List<T>.ForEach(Action<T>)` to iterate over the list.

```cs
public static void ForEachRight<T>(List<T> list, Action<T> action)
{
    Enumerable.Range(0, list.Count)
        .Reverse()
        .ToList()
        .ForEach(i => action(list[i]));
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 4 };

ForEachRight(numbers, x => Console.WriteLine(x)); // 4, 3, 2, 1
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### GroupBy
Groups the elements of a list based on the given function.

Use `Enumerable.GroupBy<TSource, TKey>(IEnumerable<TSource>, Func<TSource, TKey>)` to group the elements of the list according to the specified key selector function `Func<TSource, TKey>`. Use `Enumerable.ToDictionary<TSource, TKey, TElement>(IEnumerable<TSource>, Func<TSource, TKey>, Func<TSource, TElement>)` to create a dictionary, where the keys are produced from the mapped results.

```cs
public static Dictionary<TKey, List<T>> GroupBy<T, TKey>(List<T> list, Func<T, TKey> selector)
{
    return list.GroupBy(selector)
        .ToDictionary(x => x.Key, x => x.ToList());
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<double> { 6.1, 4.2, 6.3 };

GroupBy(numbers, Math.Floor); // { 4: { 4.2 }, 6: { 6.1, 6.3 } }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Head
Returns the head of a list.

Use `list[0]` to return the first element of the passed list.

```cs
public static T Head<T>(List<T> list)
{
    return list[0];
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3 };

Head(numbers); // 1
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### IndexOfAll
Returns all indices of `value` in a list. If `value` never occurs, returns `[]`.

Use `Enumerable.Range(Int32, Int32)` to create an int sequence, use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` to get the matched element.

```cs
public static List<int> IndexOfAll<T>(List<T> list, T value)
{
    return Enumerable.Range(0, list.Count)
        .Where(i => list[i].Equals(value))
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3, 1, 2, 3 };

IndexOfAll(numbers, 1); // { 0, 3 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Initial
Returns all the elements of a list except the last one.

Use `List<T>.GetRange(Int32, Int32)` to return all but the last element of the list.

```cs
public static List<T> Initial<T>(List<T> list)
{
    return list.Count > 1 ? list.GetRange(0, list.Count - 1) : new List<T>();
}
```

<details>
<summary>Examples</summary>

```cs
var numbers = new List<int> { 1, 2, 3 };

Initial(numbers); // { 1, 2 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Initialize2DArray
Initializes a 2D list of given width and height and value.

Use `Enumerable.Select<TSource, TResult>(IEnumerable<TSource>, Func<TSource, TResult>)` to generate `height` rows where each is a new list of size `width` initialize with value.

```cs
public static List<List<T>> Initialize2DArray<T>(int width, int height, T value)
{
    return Enumerable.Range(1, height)
        .Select(i => Enumerable.Range(1, width).Select(j => value).ToList())
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
Initialize2DArray(2, 2, 0); // { { 0, 0 }, { 0, 0 } }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### InitializeArrayWithRange
Initializes a list containing the numbers in the specified range where `start` and `end` are inclusive with their common difference `step`.

Use `Enumerable.Range(Int32, Int32)` to create a list of the desired length(the amounts of elements is equal to `(end - start) / step` or `(end + 1 - start) / step` for inclusive end), `Enumerable.Select<TSource, TResult>(IEnumerable<TSource>, Func<TSource, TResult>)` to fill with the desired values in a range. You can omit `start` to use a default value of `0`. You can omit `step` to use a default value of `1`.

```cs
public static List<int> InitializeArrayWithRange(int end, int start = 0, int step = 1)
{
    return Enumerable.Range(0, (int)Math.Ceiling((end + 1.0 - start) / step))
        .Select(i => (i * step) + start)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
InitializeArrayWithRange(5); // { 0, 1, 2, 3, 4, 5 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### InitializeArrayWithRangeRight
Initializes a list containing the numbers in the specified range (in reverse) where `start` and `end` are inclusive with their common difference `step`.

Use `Enumerable.Range(Int32, Int32)` to create a list of the desired length(the amounts of elements is equal to `(end - start) / step` or `(end + 1 - start) / step` for inclusive end), `Enumerable.Select<TSource, TResult>(IEnumerable<TSource>, Func<TSource, TResult>)` to fill with the desired values in a range. You can omit `start` to use a default value of `0`. You can omit `step` to use a default value of `1`.

```cs
public static List<int> InitializeArrayWithRangeRight(int end, int start = 0, int step = 1)
{
    var count = (int)Math.Ceiling((end + 1.0 - start) / step);

    return Enumerable.Range(0, count)
        .Select(i => ((count - i - 1) * step) + start)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
InitializeArrayWithRangeRight(5); // { 5, 4, 3, 2, 1, 0 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### InitializeArrayWithValues
Initializes and fills a list with the specified values.

Use `Enumerable.Repeat(TResult, Int32)` to create a list of the desired length and fill it with the desired values.

```cs
public static List<T> InitializeArrayWithValues<T>(int n, T value)
{
    return Enumerable.Repeat(value, n)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
InitializeArrayWithValues(5, 2); // { 2, 2, 2, 2, 2 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### InitializeNDArray
Create a n-dimensional list with given value.

Use recursion. Use `Enumerable.Repeat(TResult, Int32)` to generate rows where each is a new list initialized using `InitializeNDArray`.

```cs
public static object InitializeNDArray(object value, params int[] rows)
{
    return rows.Length == 0 ? value : Enumerable.Repeat(InitializeNDArray(value, rows.Skip(1).ToArray()), rows[0])
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
InitializeNDArray(5, 2, 2, 2); // { { { 5, 5 }, { 5, 5} }, { { 5, 5 }, {5, 5 } } }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Intersection
Returns a list of elements that exist in both lists.

Create a `HashSet` from `b`, then use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` on `a` to only keep values contained in `b`.

```cs
public static List<T> Intersection<T>(List<T> a, List<T> b)
{
    var hashSet = new HashSet<T>(b);

    return a.Where(x => hashSet.Contains(x))
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var a = new List<int> { 1, 2, 3 };
var b = new List<int> { 4, 3, 2 };
            
Intersection(a, b); // { 2, 3 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### IntersectionBy
Returns a list of elements that exist in both lists, after applying the provided function to each list element of both.

Create a `HashSet` by applying `selector` to all elements in `b`, then use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` on `a` to only keep elements, which produce values contained in `b` when `selector` is applied to them.

```cs
public static List<T> IntersectionBy<T>(List<T> a, List<T> b, Func<T, T> selector)
{
    var hashSet = new HashSet<T>(b.Select(selector));

    return a.Where(x => hashSet.Contains(selector(x)))
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var a = new List<double> { 2.1, 1.2 };
var b = new List<double> { 2.3, 3.4 };
            
IntersectionBy(a, b, Math.Floor); // { 2.1 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### IntersectionWith
Returns a list of elements that exist in both lists, using a provided comparator function.

Use `Enumerable.Where<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)` and `List<T>.FindIndex(Predicate<T>)` in combination with the provided comparator to determine intersecting values.

```cs
public static List<T> IntersectionWith<T>(List<T> a, List<T> b, Func<T, T, bool> comparator)
{
    return a.Where(x => b.FindIndex(y => comparator(x, y)) != -1)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var a = new List<double> { 1, 1.2, 1.5, 3, 0 };
var b = new List<double> { 1.9, 3, 0, 3.9 };
            
IntersectionWith(a, b, (x, y) => Math.Round(x) == Math.Round(y)); // { 1.5, 3, 0 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### IsSorted
Returns `1` if the list is sorted in ascending order, `-1` if it is sorted in descending order or `0` if it is not sorted.

Calculate the ordering direction for the first two elements. Loop over list objects and compare them in pairs. Return `0` if the `direction` changes or the `-direction` if the last element is reached.

```cs
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
```

<details>
<summary>Examples</summary>

```cs
var list = new List<int> { 0, 1, 2, 2 };
            
IsSorted(list); // 1
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Join
Joins all elements of a list into a string and returns this string. Uses a separator and an end separator.

Use `string.Join<T>(String, IEnumerable<T>)` to combine elements into a string. Omit the second argument, `separator`, to use a default separator of `","`. Omit the third argument, `endSeparator`, to use the same value as `separator` by default.

```cs
public static string Join<T>(List<T> list, string separator = ",", string endSeparator = ",")
{
    if (separator == endSeparator)
    {
        return string.Join(separator, list);
    }
    else
    {
        return string.Join(separator, list.Take(list.Count - 1)) + string.Format("{0}{1}", endSeparator, list.Last());
    }
}
```

<details>
<summary>Examples</summary>

```cs
var list = new List<string> { "pen", "pineapple", "apple", "pen" };
            
Join(list, ",", "&"); // "pen,pineapple,apple&pen"
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### Last
Returns the last element in a list.

Use `Enumerable.Last<TSource>(IEnumerable<TSource>)` to return the last element of the given list.

```cs
public static T Last<T>(List<T> list)
{
    return list.Last();
}
```

<details>
<summary>Examples</summary>

```cs
var list = new List<int> { 1, 2, 3 };
            
Last(list); // 3
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### LongestItem
Takes any number of iterable objects and returns the longest one.

Use `Enumerable.OrderBy<TSource, TKey>(IEnumerable<TSource>, Func<TSource, TKey>)` to sort all arguments by `Count`, return the last (longest) one.

```cs
public static List<T> LongestItem<T>(params List<T>[] lists)
{
    return lists.OrderBy(x => x.Count)
        .Last();
}
```

<details>
<summary>Examples</summary>

```cs
var lists = new List<int>[]
{
    new List<int> { 1, 2, 3 },
    new List<int> { 1, 2 },
    new List<int> { 1, 2, 3, 4, 5 },
};
            
LongestItem(lists); // { 1, 2, 3, 4, 5 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### MapObject
Maps the values of a list to a dictionary using a function, where the key-value pairs consist of the original value as the key and the mapped value.

Use `Enumerable.ToDictionary<TSource, TKey, TElement>(IEnumerable<TSource>, Func<TSource, TKey>, Func<TSource, TElement>)`.

```cs
public static Dictionary<TKey, TValue> MapObject<TKey, TValue>(List<TKey> list, Func<TKey, TValue> elementSelector)
{
    return list.ToDictionary(x => x, x => elementSelector(x));
}
```

<details>
<summary>Examples</summary>

```cs
var list = new List<int> { 1, 2, 3 };
           
MapObject(list, x => x * x); // { 1: 1, 2: 4, 3: 9 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)

### MaxN
Returns the `n` maximum elements from the provided list. If `n` is greater than or equal to the provided list's length, then return the original list (sorted in descending order).

Use `Enumerable.OrderByDescending<TSource, TKey>(IEnumerable<TSource>, Func<TSource, TKey>)` combined with the `Enumerable.Select<TSource, TResult>(IEnumerable<TSource>, Func<TSource, TResult>)` to create a shallow clone of the list and sort it in descending order. Use `Enumerable.Take(IEnumerable<TSource>, Int32)` to get the specified number of elements. Omit the second argument, `n`, to get a one-element list.

```cs
public static List<T> MaxN<T>(List<T> list, int n = 1)
{
    return list.Select(x => x)
        .OrderByDescending(x => x)
        .Take(n)
        .ToList();
}
```

<details>
<summary>Examples</summary>

```cs
var list = new List<int> { 1, 2, 3 };
           
MaxN(list); // { 3 }
```

</details>

<br>[⬆ Back to top](#table-of-contents)
