namespace Training.DomainClasses;

public class Alternative<TItem> : BinaryCriteria<TItem>
{
    public Alternative(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria) : base(firstCriteria, secondCriteria)
    {
    }

    public override bool IsSatisfiedBy(TItem item)
    {
        return _firstCriteria.IsSatisfiedBy(item) || _secondCriteria.IsSatisfiedBy(item);
    }
}