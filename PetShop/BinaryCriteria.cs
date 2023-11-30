namespace Training.DomainClasses;

public abstract class BinaryCriteria<T> : Criteria<T>
{
    protected Criteria<T> _criteria1;
    protected Criteria<T> _criteria2;

    public abstract bool IsSatisfiedBy(T item);
}