using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
	public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}