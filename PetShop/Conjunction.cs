namespace Training.DomainClasses;

public class Conjunction<TItem> : BinaryCriteria<TItem>
{
    public Conjunction(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria) : base(firstCriteria, secondCriteria)
    {
    }

    public override bool IsSatisfiedBy(TItem item)
    {
        return _firstCriteria.IsSatisfiedBy(item) && _secondCriteria.IsSatisfiedBy(item);
    }
}