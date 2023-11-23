using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public bool Equals(Pet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pet)obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static ICriteria<Pet> IsSpecies(Species species)
        {
            return new IsSpeciesCriteria(species);
        }

        public static ICriteria<Pet> IsSex(Sex sex)
        {
            return new IsSexCriteria(sex);
        }

        public static ICriteria<Pet> IsNotSpecies(Species species)
        {
            return new IsNotSpeciesCriteria(species);
        }

        public static ICriteria<Pet> IsBornAfter(int year)
        {
            return new BornAfterCriteria(year);
        }
    }

    public class IsNotSpeciesCriteria : ICriteria<Pet>
    {
        private readonly Species _species;

        public IsNotSpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species != _species;
        }
    }

    public class IsSexCriteria : ICriteria<Pet>
    {
        private readonly Sex _sex;

        public IsSexCriteria(Sex sex)
        {
            _sex = sex;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.sex == _sex;
        }
    }

    public class IsSpeciesCriteria : ICriteria<Pet>
    {
        private readonly Species _species;

        public IsSpeciesCriteria(Species species)
        {
            _species = species;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return item.species == _species;
        }
    }

    public class BornAfterCriteria : ICriteria<Pet>
    {
        private readonly int _year;
        public BornAfterCriteria(int year)
        {
            _year = year;
        }
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth > _year;
        }
    }
}