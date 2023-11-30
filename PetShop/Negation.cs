namespace Training.DomainClasses;

public class Negation<TItem> : Criteria<TItem>
{
    private readonly Criteria<TItem> _innerCriteria;
    public Negation(Criteria<TItem> criteria)
    {
        _innerCriteria = criteria;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return !_innerCriteria.IsSatisfiedBy(item);
    }
}