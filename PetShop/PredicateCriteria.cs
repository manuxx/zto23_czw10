using System;

public class PredicateCriteria<T> : Criteria<T>
{
    private Predicate<T> myPredicate;
    public PredicateCriteria(Predicate<T> condition)
    {
        myPredicate = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return myPredicate(item);
    }
}