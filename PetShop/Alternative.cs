namespace Training.DomainClasses;

public class Alternative<TItem> : Criteria<TItem>
{
    private Criteria<TItem> _innerCriteria2;
    private Criteria<TItem> _innerCriteria3;
    public Alternative(Criteria<TItem> isASpeciesOf, Criteria<TItem> isBornAfter)
    {
        _innerCriteria2 = isASpeciesOf;
        _innerCriteria3 = isBornAfter;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _innerCriteria2.IsSatisfiedBy(item) || _innerCriteria3.IsSatisfiedBy(item);
    }
}