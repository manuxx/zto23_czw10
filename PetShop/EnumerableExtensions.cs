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
    
    public static IEnumerable<T> ThatSatisfy<T>(this IEnumerable<T> collection, Predicate<T> condition)
    {
        foreach (var item in collection)
        {
            if (condition(item))
                yield return item;
        }
    }
}