using System.Collections.Generic;

public static class EnumerableUtils
{
    public static IEnumerable<T> GetCollectionAsEnumerable<T>(this IEnumerable<T> collection)
    {
        foreach (var element in collection)
        {
            yield return element;
        }
    }
}