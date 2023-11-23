using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ReadOnly<TItem> : IEnumerable<TItem>
{
    private readonly IEnumerable<TItem> _enumerable;

    public ReadOnly(IEnumerable<TItem> pets)
    {
        _enumerable = pets;
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}