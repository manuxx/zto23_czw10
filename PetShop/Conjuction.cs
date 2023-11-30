namespace Training.DomainClasses;

public class Conjuction<TItem> : BinaryCriteria<TItem>
{
	public Conjuction(Criteria<TItem> criteria1, Criteria<TItem> criteria2) : base(criteria1, criteria2)
	{
	}

	public override bool IsSatisfiedBy(TItem item)
	{
		return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
	}
}