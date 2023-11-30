namespace Training.DomainClasses;

public class Alternative<T> : BinaryCriteria<T>
{
    public Alternative(Criteria<T> criteria1, Criteria<T> criteria2)
    {
        _criteria1 = criteria1;
        _criteria2 = criteria2;
    }

    public override bool IsSatisfiedBy(T item)
    {
        return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
    }
}