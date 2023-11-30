namespace Training.DomainClasses;

public class Alternative<TItem> : Criteria<TItem>
{
    private readonly Criteria<TItem> _criteria_1;
    private readonly Criteria<TItem> _criteria_2;

    public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        _criteria_1 = criteria1;
        _criteria_2 = criteria2;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _criteria_1.IsSatisfiedBy(item) || _criteria_2.IsSatisfiedBy(item);
    }
}