namespace Training.DomainClasses;

public class Negation : Criteria<Pet>
{
    private readonly Criteria<Pet> _innerCriteria;

    public Negation(Criteria<Pet> innerCriteria)
    {
        _innerCriteria = innerCriteria;
    }

    public bool IsSatisfiedBy(Pet item)
    {
        return !_innerCriteria.IsSatisfiedBy(item);
    }
}