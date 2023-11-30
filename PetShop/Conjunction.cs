namespace Training.DomainClasses;

public class Conjunction<TItem> : Criteria<TItem>
{
    private Criteria<TItem> _innerCriteria1;
    private Criteria<TItem> _innerCriteria2;
    public Conjunction(Criteria<TItem> isASpeciesOf, Criteria<TItem> isBornAfter)
    {
        _innerCriteria1 = isASpeciesOf;
        _innerCriteria2 = isBornAfter;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _innerCriteria1.IsSatisfiedBy(item) && _innerCriteria2.IsSatisfiedBy(item);
    }
}