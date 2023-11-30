using Training.DomainClasses;

public static class CriteriaExtensions
{
	public static Alternative<Pet> Or(this Criteria<Pet> criteria1, Criteria<Pet> criteria2)
	{
		return new Alternative<Pet>(criteria1, criteria2);
	}

	public static Conjuction<Pet> And(this Criteria<Pet> criteria1, Criteria<Pet> criteria2)
	{
		return new Conjuction<Pet>(criteria1, criteria2);
	}
}