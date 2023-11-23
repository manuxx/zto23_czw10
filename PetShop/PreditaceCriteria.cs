using System;

public class PreditaceCriteria<TItem> : Criteria<TItem>
{
    private readonly Predicate<TItem> _condition;
    public PreditaceCriteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _condition(item);
    }
}