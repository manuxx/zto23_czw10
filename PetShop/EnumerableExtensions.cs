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

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> petsInTheStore, Predicate<TItem> condition)
    {
        return ThatSatisfy(petsInTheStore, new PredicateCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> petsInTheStore, ICriteria<TItem> criteria)
    {
        foreach (var pet in petsInTheStore)
        {
            if (criteria.IsSatisfiedBy(pet))
                yield return pet;
        }
    }
}

public class PredicateCriteria<T> : ICriteria<T>
{
    private Predicate<T> _condition;
    public PredicateCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface ICriteria<T>
{
    bool IsSatisfiedBy(T item);
}