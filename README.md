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

### Any
Returns `true` if the provided predicate function returns `true` for at least one element in a collection, `false` otherwise.

Use `List<T>.Exists(Predicate<T>)` to test if any elements in the collection return `true` based on `Predicate<T>`.

```cs
public static bool Any<T>(List<T> list, Predicate<T> predicate)
{
    return list.Exists(predicate);
}
```

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
