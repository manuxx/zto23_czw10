namespace Training.DomainClasses;

public static class CriteriaExtension
{
    public static Alternative<T> Or<T>(this Criteria<T> criteria1, Criteria<T> criteria2)
    {
        return new Alternative<T>(criteria1, criteria2);
    }
}