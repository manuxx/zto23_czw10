namespace Training.DomainClasses;

public class Alternative<TItem> : Criteria<TItem>
{
    private readonly Criteria<TItem>[] _criterias;

    public Alternative(params Criteria<TItem>[] criterias)
    {
        _criterias = criterias;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        foreach (var criteria in _criterias)
        {
            if (criteria.IsSatisfiedBy(item))
            {
                return true;
            }
        }

        return false;
    }
}