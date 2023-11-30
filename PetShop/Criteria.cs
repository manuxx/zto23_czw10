using Training.DomainClasses;

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);

    public Criteria<TItem> Or(Criteria<TItem> other)
    {
        return new Alternative<TItem>(this, other);
    }

    public Criteria<TItem> And(Criteria<TItem> other)
    {
        return new Conjuction<TItem>(this, other);
    }
}