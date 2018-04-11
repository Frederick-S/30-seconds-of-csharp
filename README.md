# 30-seconds-of-csharp [![CircleCI](https://circleci.com/gh/Frederick-S/30-seconds-of-csharp.svg?style=shield)](https://circleci.com/gh/Frederick-S/30-seconds-of-csharp) [![Build status](https://ci.appveyor.com/api/projects/status/e58yuk2bbrmtde7c?svg=true)](https://ci.appveyor.com/project/Frederick-S/30-seconds-of-csharp) [![codecov](https://codecov.io/gh/Frederick-S/30-seconds-of-csharp/branch/master/graph/badge.svg)](https://codecov.io/gh/Frederick-S/30-seconds-of-csharp)

> Curated collection of useful C# snippets that you can understand in 30 seconds or less.

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

### Compact
Removes null values from a list.

Use `List<T>.FindAll(Predicate<T>)` to filter out null values.

```cs
public static List<T> Compact<T>(List<T> list)
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
