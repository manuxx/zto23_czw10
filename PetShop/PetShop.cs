using System;
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
            // nie czytamy linia po linii tylko ma sens razem, "stworz iterator"
            // to jest idiom - kompilator jak widzi taki kod to czyta to jako "zrob z tego iterator"
            // jako ze ten iterator nie bedzie wykorzystany, petla sie nie wykona ani razu
            foreach (var pet in _petsInTheStore)
            {
                yield return pet;
            }
        }

        public void Add(Pet newPet)
        {
             foreach (var pet in _petsInTheStore)
                if (newPet.name==pet.name)
                    return;
             _petsInTheStore.Add(newPet);
        }
    }
}