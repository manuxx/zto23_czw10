namespace Training.DomainClasses;

public class Alternative : BinaryCriteria
{
    public Alternative(Criteria<Pet> criteria1, Criteria<Pet> criteria2) : base(criteria1, criteria2)
    {
    }

    public override bool IsSatisfiedBy(Pet item)
    {
        return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
    }
}