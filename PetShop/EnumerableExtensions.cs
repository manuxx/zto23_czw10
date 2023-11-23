using System;
using System.Collections.Generic;
using System.Reflection;
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

    public static IEnumerable<TItem> GetAllThatMatch<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        return items.GetAllThatMatch(new PredicateCriteria<TItem>(condition));
    }
    public static IEnumerable<TItem> GetAllThatMatch<TItem>(this IEnumerable<TItem> items, ICriteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public interface ICriteria<T>
{
    bool IsSatisfiedBy(T item);
}

public class PredicateCriteria<T> : ICriteria<T>
{
    private Predicate<T> myPredicate;
    public PredicateCriteria(Predicate<T> condition)
    {
        myPredicate = condition;
    }

    public bool IsSatisfiedBy(T pet)
    {
        return (myPredicate(pet));
    }
}