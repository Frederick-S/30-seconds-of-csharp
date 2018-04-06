# 30-seconds-of-csharp [![CircleCI](https://circleci.com/gh/Frederick-S/30-seconds-of-csharp.svg?style=shield)](https://circleci.com/gh/Frederick-S/30-seconds-of-csharp) [![Build status](https://ci.appveyor.com/api/projects/status/e58yuk2bbrmtde7c?svg=true)](https://ci.appveyor.com/project/Frederick-S/30-seconds-of-csharp) [![codecov](https://codecov.io/gh/Frederick-S/30-seconds-of-csharp/branch/master/graph/badge.svg)](https://codecov.io/gh/Frederick-S/30-seconds-of-csharp)

> Curated collection of useful C# snippets that you can understand in 30 seconds or less.

## Table of Contents

### List

<details>
<summary>View contents</summary>

* [`All`](#all)
* [`Any`](#any)
* [`Bifurcate`](#bifurcate)

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
Splits values into two groups. If an element in `Predicate<T>` is truthy, the corresponding element in the collection belongs to the first group; otherwise, it belongs to the second group.

Use `Aggregate<TSource,TAccumulate>(IEnumerable<TSource>, TAccumulate, Func<TAccumulate,TSource,TAccumulate>)` and `List<T>.Add(T)` to add elements to groups, based on `Predicate<T>`.

```cs
public static List<List<T>> Bifurcate<T>(List<T> list, Predicate<T> predicate)
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
