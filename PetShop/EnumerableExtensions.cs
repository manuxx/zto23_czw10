using System.Collections.Generic;

namespace Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            yield return item;
        }
    }
}