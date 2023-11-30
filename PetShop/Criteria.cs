using System;

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);

    public static Criteria<TItem> operator &(Criteria<TItem> left, Criteria<TItem> right)
    {
        return new Conjunction<TItem>(left, right);
    }

    public static Criteria<TItem> operator |(Criteria<TItem> left, Criteria<TItem> right)
    {
        return new Disjunction<TItem>(left, right);
    }

    public static Criteria<TItem> operator !(Criteria<TItem> criteria)
    {
        return new Negation<TItem>(criteria);
    }
}

public abstract class BinaryCriteria<TItem> : Criteria<TItem>
{
    protected Criteria<TItem> _criteria1;
    protected Criteria<TItem> _criteria2;

    public BinaryCriteria(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        _criteria1 = criteria1;
        _criteria2 = criteria2;
    }

    public abstract bool IsSatisfiedBy(TItem item);
}

public class Conjunction<TItem> : BinaryCriteria<TItem>
{
    public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2) : base(criteria1, criteria2)
    {
    }

    public override bool IsSatisfiedBy(TItem item)
    {
        return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
    }
}

public class Disjunction<TItem> : BinaryCriteria<TItem>
{
    public Disjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2) : base(criteria1, criteria2)
    {
    }

    public override bool IsSatisfiedBy(TItem item)
    {
        return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
    }
}

public class Negation<TItem> : Criteria<TItem>
{
    private readonly Criteria<TItem> _criteria;

    public Negation(Criteria<TItem> isASpeciesOf)
    {
        _criteria = isASpeciesOf;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return !_criteria.IsSatisfiedBy(item);
    }
}

public class Where<TItem>
{
    public static CriteriaCreator<TItem, TProperty> HasAn<TProperty>(Func<TItem, TProperty> fieldExtractor)
    {
        return new CriteriaCreator<TItem, TProperty>(fieldExtractor);
    }

    public static ComparableCriteriaCreator<TItem, TProperty> HasComparable<TProperty>(Func<TItem, TProperty> fieldExtractor) where TProperty : IComparable<TProperty>
    {
        return new ComparableCriteriaCreator<TItem, TProperty>(fieldExtractor);
    }
}

public class ComparableCriteriaCreator<TItem, TProperty> where TProperty : IComparable<TProperty>
{
    private readonly Func<TItem, TProperty> _fieldExtractor;

    public ComparableCriteriaCreator(Func<TItem, TProperty> fieldExtractor)
    {
        _fieldExtractor = fieldExtractor;
    }

    public Criteria<TItem> GreaterThan(TProperty item)
    {
        return new PredicateCriteria<TItem>(p => _fieldExtractor(p).CompareTo(item) > 0);
    }
}

public class CriteriaCreator<TItem, TProperty>
{
    private readonly Func<TItem, TProperty> _fieldExtractor;

    public CriteriaCreator(Func<TItem, TProperty> fieldExtractor)
    {
        _fieldExtractor = fieldExtractor;
    }

    public Criteria<TItem> EqualTo(TProperty item)
    {
        return new PredicateCriteria<TItem>(p => _fieldExtractor(p).Equals(item));
    }
}