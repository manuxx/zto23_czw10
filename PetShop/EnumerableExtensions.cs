using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<T> OneAtTheTime<T>(this IEnumerable<T> itemsList)
    {
        foreach (var item in itemsList)
        {
            yield return item;
        }
    }
}