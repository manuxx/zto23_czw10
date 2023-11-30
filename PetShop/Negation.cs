namespace Training.DomainClasses;

public class Negation<TItem> : Criteria<TItem>
{
    private Criteria<TItem> _wrappedCriteria;
    public Negation(Criteria<TItem> inputCriteria)
    {
        _wrappedCriteria = inputCriteria;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return !_wrappedCriteria.IsSatisfiedBy(item);
    }
}