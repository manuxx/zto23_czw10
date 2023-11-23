using System;

public interface Criteria<T>
{
    bool isSatisfiedBy(T item);
}

public class PredicateCriteria<T> : Criteria<T>
{
    private Predicate<T> myPredicate;
    public PredicateCriteria(Predicate<T> condition)
    {
        myPredicate = condition;
    }

    public bool isSatisfiedBy(T item)
    {
        return (myPredicate(item));
    }
}