using System;

namespace Training.DomainClasses
{
    public record Pet
    {
        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }
    }
}