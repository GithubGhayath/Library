using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.ValueObjects
{
    public class Address
    {
        public string? City { get; }
        public  string? Street{ get;  }
        public string? ZipCode { get;  }

        public Address(string city, string street,string zipCode)
        {
            City = city;
            Street = street;
            ZipCode = zipCode;
        }


        private Address() { }

    }
}
