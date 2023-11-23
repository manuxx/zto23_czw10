using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ReadOnly<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> _pets;

    public ReadOnly(IEnumerable<T> pets)
    {
        _pets = pets;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _pets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}