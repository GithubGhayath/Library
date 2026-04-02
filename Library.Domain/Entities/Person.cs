using Library.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Library.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public char Gender { get; set; }

        public Address? Address { get; private set; }
        public Email? Email { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers {  get; set; }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public Person(string firstName, string lastName, char gender, Address? address)
        {

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Address = address;
        }

        public Person(Address address)
        {
            Address = address;
        }
    }
}
