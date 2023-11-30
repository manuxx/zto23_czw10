namespace Training.DomainClasses;

public static class CriteriaExtensions
{
    public static Conjunction And(this Criteria<Pet> criteria1, Criteria<Pet> criteria2)
    {
        return new Conjunction(criteria1, criteria2);
    }

    public static Alternative Or(this Criteria<Pet> criteria1, Criteria<Pet> criteria2)
    {
        return new Alternative(criteria1, criteria2);
    }
}