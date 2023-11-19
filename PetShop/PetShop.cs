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

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.Filter(pet => pet.species == Species.Cat);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var sorted =  new List<Pet>(_petsInTheStore);
            sorted.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
            return sorted;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.Filter(pet => pet.species == Species.Mouse);
        }
        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.Filter(pet => pet.sex == Sex.Female);
        }
        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.Filter(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }
        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.Filter(pet => pet.species != Species.Mouse);
        }
        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.Filter(pet => pet.yearOfBirth > 2010);
        }
        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.Filter(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.Filter(pet => pet.species == Species.Dog && pet.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.Filter(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        }
        
    }

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
}