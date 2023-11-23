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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Predicate<TItem> condition)
    {
	    Criteria<TItem> adapter = new PredicateCriteria<TItem>(condition);
	    /*foreach (var item in items)
	    {
		    if (condition(item))
			    yield return item;
	    }*/
	    return items.ThatSatisfy(adapter);
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
    {
	    foreach (var item in items)
	    {
		    if (criteria.IsSatisfiedBy(item))
			    yield return item;
	    }
    }
}

public class PredicateCriteria<T> : Criteria<T>
{
	private readonly Predicate<T> predicate;
	public PredicateCriteria(Predicate<T> condition)
	{
		this.predicate = condition;
	}

	public bool IsSatisfiedBy(T item)
	{
		return predicate(item);
	}
}

public interface Criteria<TItem>
{
	bool IsSatisfiedBy(TItem item);
}