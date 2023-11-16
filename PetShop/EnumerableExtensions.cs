using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(IList<TItem> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
        }
    }
}