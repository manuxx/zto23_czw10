using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> items)
    {
        foreach (var pet in items)
        {
            yield return pet;
        }
    }
}