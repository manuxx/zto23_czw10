namespace Training.DomainClasses;

public class Negation<T> : Criteria<T>
{
    private readonly Criteria<T> _criteria;
        
    public Negation(Criteria<T> criteria)
    {
        _criteria = criteria;
    }

    public bool IsSatisfiedBy(T item)
    {
        return !_criteria.IsSatisfiedBy(item);
    }
}