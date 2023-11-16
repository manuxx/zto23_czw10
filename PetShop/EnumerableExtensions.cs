using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{

    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
    public static bool ShouldContainOnly<TItem>(this IEnumerable<TItem> items, params TItem[] elements)
    {
        return false;
    }

    public static IEnumerable<TItem> Filter<TItem>(this IEnumerable<TItem> items, Predicate<TItem> predicate)
    {
        foreach (var item in items)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
}