using System;

public class PredicateCriteria<TItem> : Criteria<TItem>
{
    private readonly Predicate<TItem> _condition;

    public PredicateCriteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _condition(item);
    }
}