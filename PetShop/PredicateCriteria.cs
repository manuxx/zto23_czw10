using System;

public class PredicateCriteria<T> : ICriteria<T>
{
    private Predicate<T> _condition;
    public PredicateCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}