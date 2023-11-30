using System;
using Training.DomainClasses;

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);

    Criteria<TItem> Or(Criteria<TItem> otherCriteria)
    {
        return new Alternative<TItem>(this, otherCriteria);
    }

    Criteria<TItem> And(Criteria<TItem> otherCriteria)
    {
        return new Conjunction<TItem>(this, otherCriteria);
    }
}