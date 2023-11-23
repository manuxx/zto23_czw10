using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ReadOnly<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> _items;

    public ReadOnly(IEnumerable<T> items)
    {
        _items = items;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}