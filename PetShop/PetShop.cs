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
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice()
        {
            return GetFilteredPets(pet => pet.species.Equals(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return GetFilteredPets(pet => pet.sex.Equals(Sex.Female));
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return GetFilteredPets(pet => pet.species.Equals(Species.Cat) || pet.species.Equals(Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return GetFilteredPets(pet => !pet.species.Equals(Species.Mouse));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return GetFilteredPets(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return GetFilteredPets(pet => pet.yearOfBirth > 2010 && pet.species.Equals(Species.Dog));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return GetFilteredPets(pet => pet.sex.Equals(Sex.Male) && pet.species.Equals(Species.Dog));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return GetFilteredPets(pet => pet.yearOfBirth > 2011 || pet.species.Equals(Species.Rabbit));
        }

        private IEnumerable<Pet> GetFilteredPets(Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (condition.Invoke(pet))
                {
                    yield return pet;
                }
            }
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