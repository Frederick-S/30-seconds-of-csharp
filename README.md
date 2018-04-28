# 30-seconds-of-csharp [![CircleCI](https://circleci.com/gh/Frederick-S/30-seconds-of-csharp.svg?style=shield)](https://circleci.com/gh/Frederick-S/30-seconds-of-csharp) [![Build status](https://ci.appveyor.com/api/projects/status/e58yuk2bbrmtde7c?svg=true)](https://ci.appveyor.com/project/Frederick-S/30-seconds-of-csharp) [![codecov](https://codecov.io/gh/Frederick-S/30-seconds-of-csharp/branch/master/graph/badge.svg)](https://codecov.io/gh/Frederick-S/30-seconds-of-csharp)

> .NET Core translations of [30-seconds-of-code](https://github.com/Chalarangelo/30-seconds-of-code).

## Table of Contents

### List

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

</details>

## List
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

Use `List<T>.FindAll(Predicate<T>)` to filter out null values.

```cs
public static List<T> Compact<T>(List<T> list)
    where T : class
{
    return list.FindAll(x => x != null).ToList();
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

Create a `HashSet<T>` from `b`, then use `List<T>.FindAll(Predicate<T>)` on `a` to only keep values not contained in `b`.

```cs
public static List<T> Difference<T>(List<T> a, List<T> b)
{
    var hashSet = new HashSet<T>(b);

    return a.FindAll(x => !hashSet.Contains(x));
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

Create a `HashSet<T>` by applying `selector` to each element in `b`, then use `List<T>.FindAll(Predicate<T>)` in combination with `selector` on `a` to only keep values not contained in the previously created `HashSet<T>`.

```cs
public static List<T> DifferenceBy<T>(List<T> a, List<T> b, Func<T, T> selector)
{
    var hashSet = new HashSet<T>(b.Select(selector));

    return a.FindAll(x => !hashSet.Contains(selector(x)));
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

Use `List<T>.FindAll(Predicate<T>)` and `List<T>.FindIndex(Predicate<T>)` to find the appropriate values.

```cs
public static List<T> DifferenceWith<T>(List<T> a, List<T> b, Func<T, T, bool> comparator)
{
    return a.FindAll(x => b.FindIndex(y => comparator(x, y)) == -1);
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
    return list.Skip(n).ToList();
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
    return list.Take(list.Count - n).ToList();
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

Use `List<T>.FindAll(Predicate<T>)` for a list containing only the unique values.

```cs
public static List<T> FilterNonUnique<T>(List<T> list)
{
    return list.FindAll(x => list.IndexOf(x) == list.LastIndexOf(x))
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
