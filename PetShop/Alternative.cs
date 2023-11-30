namespace Training.DomainClasses;

public class Alternative<T> : Criteria<T>
{
    private readonly Criteria<T> _criteria1;
    private readonly Criteria<T> _criteria2;
    public Alternative(Criteria<T> criteria1, Criteria<T> criteria2)
    {
        _criteria1 = criteria1;
        _criteria2 = criteria2;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
    }
}