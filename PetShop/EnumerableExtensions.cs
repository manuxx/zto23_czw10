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

    public static IEnumerable<TItem> ThatMatch<TItem>(this IList<TItem> items, Predicate<TItem> condition)
    {
        Criteria<TItem> adapter = new PredicateCriteria<TItem>(condition);

        return items.ThatMatch(adapter);
    }

    public static IEnumerable<TItem> ThatMatch<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.isSatisfiedBy(item))
                yield return item;
        }
    }
}
