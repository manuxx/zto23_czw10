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
           
                foreach (var pet in _petsInTheStore)
                {
                    if (pet.name == newPet.name)
                    {
                        return;
                    }
                }
                _petsInTheStore.Add(newPet);

        }


        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2)=>p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Cat));
        }
        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsASpeciesOf(Species.Mouse));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsFemale());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Cat || pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.ThatSatisfy(Pet.IsNotASpecieOf(Species.Mouse));
        }


        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Dog && pet.yearOfBirth > 2010));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Dog && pet.sex == Sex.Male));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.ThatSatisfy((pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011));
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