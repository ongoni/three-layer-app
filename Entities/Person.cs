using System;
using System.Collections.Generic;

namespace Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Medal> Medals { get; set; }
        
        public override string ToString() => $"{Id} - {FirstName} {LastName}, age: {Age}, born: {BirthDate: dd-MMM-yyyy}";
    }
}