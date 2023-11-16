using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> sortedByName = new List<Pet>(_petsInTheStore);
            sortedByName.Sort((p1, p2) => p1.name.CompareTo(p2.name));
            return sortedByName;
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.species == Species.Cat)
                    yield return pet;
        }

        public IEnumerable<Pet> AllMice()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.species == Species.Mouse)
                    yield return pet;
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.sex == Sex.Female)
                    yield return pet;
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.species == Species.Cat || pet.species == Species.Dog)
                    yield return pet;
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.species != Species.Mouse)
                    yield return pet;
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.yearOfBirth > 2010)
                    yield return pet;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.yearOfBirth > 2010 && pet.species == Species.Dog)
                    yield return pet;
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.sex == Sex.Male && pet.species == Species.Dog)
                    yield return pet;
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            foreach (var pet in _petsInTheStore)
                if (pet.yearOfBirth > 2011 || pet.species == Species.Rabbit)
                    yield return pet;
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