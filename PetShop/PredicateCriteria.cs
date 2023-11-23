using System;

public class PredicateCriteria<T> : ICriteria<T>
{
    private Predicate<T> condition;
    public PredicateCriteria(Predicate<T> condition)
    {
        this.condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return condition(item);
    }
}