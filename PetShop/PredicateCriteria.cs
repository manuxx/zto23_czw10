using System;

class PredicateCriteria<TItem> : ICriteria<TItem>
{
    private Predicate<TItem> predicate;
    public PredicateCriteria(Predicate<TItem> predicate)
    {
        this.predicate = predicate;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return predicate(item);
    }
}