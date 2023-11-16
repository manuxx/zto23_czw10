using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> petsInTheStore)
    {
        foreach (var item in petsInTheStore)
        {
            yield return item;
        }
    }
}