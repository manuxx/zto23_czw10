using System;
using System.Diagnostics.CodeAnalysis;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public bool Equals([AllowNull] Pet other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (other.name == name)
                return true;

            return false;
        }
    }
}