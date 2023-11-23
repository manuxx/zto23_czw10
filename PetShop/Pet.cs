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

        public static Criteria<Pet> IsASpecieOf(Species specie)
        {
            return new SpeciesCritera(specie);
        }

        public static Criteria<Pet> IsAFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static Predicate<Pet> IsNotASpecieOf(Species specie)
        {
            return pet => pet.species != specie;
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BornCriteria(year);
        }
    }

    public class SexCriteria : Criteria<Pet>
    {

        private Sex _sex;
        public SexCriteria(Sex sex)
        {
            _sex = sex;
        }

        public bool isSatisfiedBy(Pet item)
        {
            return item.sex == _sex;
        }
    }

    public class SpeciesCritera : Criteria<Pet>
    {
        private Species _specie;
        public SpeciesCritera(Species specie)
        {
            _specie = specie;
        }

        public bool isSatisfiedBy(Pet item)
        {
            return item.species == _specie;
        }
    }

    public class BornCriteria : Criteria<Pet>
    {
        private int _year;
        public BornCriteria(int year)
        {
            this._year = year;
        }

        public bool isSatisfiedBy(Pet item)
        {
            return item.yearOfBirth > 2010;
        }
    }
}