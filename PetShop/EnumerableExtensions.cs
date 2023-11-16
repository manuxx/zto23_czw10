using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<ElementType> OneAtATime<ElementType>(this IEnumerable<ElementType> collection)
    {
        foreach (var element in collection)
        {
            yield return element;
        }
    }
}