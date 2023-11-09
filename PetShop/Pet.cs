using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        bool IEquatable<Pet>.Equals(Pet other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other.name == this.name) return true;
            return false;
        }
    }
}