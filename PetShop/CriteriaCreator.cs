using System;

public static class CriteriaCreator
{
    public static Criteria<TItem> GreaterThan<TItem, TProperty>(this CriteriaCreator<TItem, TProperty> criteria, TProperty item)
        where TProperty : IComparable<TProperty>
    {
        return new PredicateCriteria<TItem>(p => criteria._fieldExtractor(p).CompareTo(item) > 0);
    }
}

public class CriteriaCreator<TItem, TProperty>
{
    internal readonly Func<TItem, TProperty> _fieldExtractor;

    public CriteriaCreator(Func<TItem, TProperty> fieldExtractor)
    {
        _fieldExtractor = fieldExtractor;
    }

    public Criteria<TItem> EqualTo(TProperty item)
    {
        return new PredicateCriteria<TItem>(p => _fieldExtractor(p).Equals(item));
    }
}