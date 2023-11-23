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
        ICriteria<T> adapter = new PredicateCriteria<T>(condition);
        return collection.ThatSatisfy(adapter);
    }
    
    public static IEnumerable<T> ThatSatisfy<T>(this IEnumerable<T> collection, ICriteria<T> criteria)
    {
        foreach (var item in collection)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}