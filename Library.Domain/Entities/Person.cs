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
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public char Gender { get; set; }

        public Address? Address { get; private set; }
        public AuditTimestamp? AuditTimestamp { get; set; }
        public Email? Email { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
        public User? User { get; set; }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }
        public void UpdateEmail(Email email)
        {
            Email = email;
        }

        public Person(string firstName, string lastName, char gender, Address? address, Email? email)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Address = address;
            Email = email;
            AuditTimestamp = new AuditTimestamp();
        }

        public Person(Address address, Email email)
        {
            Address = address;
            Email = email;
        }
        public Person(){ }
    }
}
