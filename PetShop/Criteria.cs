using Training.DomainClasses;

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);

    public static Criteria<TItem> operator &(Criteria<TItem> a, Criteria<TItem> b)
    {
        return new Conjuction<TItem>(a, b);
    }

    public static Criteria<TItem> operator |(Criteria<TItem> a, Criteria<TItem> b)
    {
        return new Alternative<TItem>(a, b);
    }

    public static Criteria<TItem> operator !(Criteria<TItem> criteria)
    {
        return new Negation<TItem>(criteria);
    }
}