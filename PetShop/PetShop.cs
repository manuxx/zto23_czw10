using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            _petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return _petsInTheStore;
        }

        public void Add(Pet newPet)
        {
<<<<<<< HEAD
            if(!_petsInTheStore.Contains(newPet))
            _petsInTheStore.Add(newPet);
=======
             foreach (var pet in _petsInTheStore)
                if (newPet.name==pet.name)
                    return;
             _petsInTheStore.Add(newPet);

>>>>>>> main
        }
    }
}