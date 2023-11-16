using System;
using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnly(_petsInTheStore);
        }

        public class ReadOnly : IEnumerable<Pet>
        {
            private readonly IList<Pet> _petsInTheStore;

            public ReadOnly(IList<Pet> petsInTheStore)
            {
                _petsInTheStore = petsInTheStore;
            }

            public IEnumerator<Pet> GetEnumerator()
            {
                return _petsInTheStore.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private static IEnumerable<Pet> OneAtATime(IList<Pet> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }

        public void Add(Pet newPet)
        {
            if (!_petsInTheStore.Contains(newPet))
            {
                foreach (var pet in _petsInTheStore)
                {
                    if (pet.name == newPet.name)
                    {
                        return;
                    }
                }
                _petsInTheStore.Add(newPet);
            }

        }
    }
}