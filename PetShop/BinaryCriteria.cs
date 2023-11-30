namespace Training.DomainClasses;

public abstract class BinaryCriteria<T> : Criteria<T>
{
    protected Criteria<T> _criteria1;
    protected Criteria<T> _criteria2;

    public BinaryCriteria(Criteria<T> criteria1, Criteria<T> criteria2)
    {
        _criteria1 = criteria1;
        _criteria2 = criteria2;
    }

    public abstract bool IsSatisfiedBy(T item);
}