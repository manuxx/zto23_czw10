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

        public void Add(Pet newItem)
        {
           
                foreach (var pet in _petsInTheStore)
                {
                    if (pet.name == newItem.name)
                    {
                        return;
                    }
                }
                _petsInTheStore.Add(newItem);

        }


        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.ThatMatch(IsASpecieOf(Species.Cat));
        }
        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.ThatMatch(IsASpecieOf(Species.Mouse));
        }

        private static Predicate<Pet> IsASpecieOf(Species specie)
        {
            return (pet => pet.species == specie);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.ThatMatch(IsAFemale());
        }

        private static Predicate<Pet> IsAFemale()
        {
            return (pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.ThatMatch((pet => pet.species == Species.Cat || pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatMatch(IsNotASpecieOf(Species.Mouse));
        }

        private static Predicate<Pet> IsNotASpecieOf(Species specie)
        {
            return pet => pet.species != specie;
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.ThatMatch(IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.ThatMatch((pet => pet.species == Species.Dog && pet.yearOfBirth > 2010));
        }

        private static Predicate<Pet> IsBornAfter(int year)
        {
            return (pet => pet.yearOfBirth > year);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatMatch((pet => pet.species == Species.Dog && pet.sex == Sex.Male));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatMatch((pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011));
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