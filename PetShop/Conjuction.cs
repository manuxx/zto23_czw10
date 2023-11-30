namespace Training.DomainClasses;

public class Conjuction<TItem> : Criteria<TItem>
{
    private readonly Criteria<TItem>[] _criterias;

    public Conjuction(params Criteria<TItem>[] criterias)
    {
        _criterias = criterias;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        foreach (var criteria in _criterias)
        {
            if (!criteria.IsSatisfiedBy(item))
            {
                return false;
            }
        }

        return true;
    }
}