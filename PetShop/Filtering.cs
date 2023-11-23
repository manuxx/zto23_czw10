using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DomainClasses;

public static class Filtering
{
    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        Criteria<TItem> adapter = new PredicateCriteria<TItem>(condition);

        return items.ThatSatisfy(adapter);
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
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
    private Predicate<T> _condition;
    public PredicateCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T pet)
    {
        return _condition(pet);
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(T pet);
}
