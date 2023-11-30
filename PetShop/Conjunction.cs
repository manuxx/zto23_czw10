namespace Training.DomainClasses;

public abstract class BinaryCriteria : Criteria<Pet>
{
    protected Criteria<Pet> _criteria1;
    protected Criteria<Pet> _criteria2;

    public BinaryCriteria(Criteria<Pet> criteria1, Criteria<Pet> criteria2)
    {
        _criteria1 = criteria1;
        _criteria2 = criteria2;
    }

    public abstract bool IsSatisfiedBy(Pet item);
}

public class Conjunction : BinaryCriteria
{
    public Conjunction(Criteria<Pet> criteria1, Criteria<Pet> criteria2) : base(criteria1, criteria2)
    {
    }

    public override bool IsSatisfiedBy(Pet item)
    {
        return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
    }
}