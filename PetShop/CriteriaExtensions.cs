using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static Conjunction<T> And<T>(this Criteria<T> criteria1, Criteria<T> criteria2)
    {
        return new Conjunction<T>(criteria1, criteria2);
    }

    public static Alternative<T> Or<T>(this Criteria<T> criteria1, Criteria<T> criteria2)
    {
        return new Alternative<T>(criteria1, criteria2);
    }
}