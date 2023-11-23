using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ReadOnly : IEnumerable<Pet>
{
    private readonly IEnumerable<Pet> _pets;

    public ReadOnly(IEnumerable<Pet> pets)
    {
        _pets = pets;
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        return _pets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}