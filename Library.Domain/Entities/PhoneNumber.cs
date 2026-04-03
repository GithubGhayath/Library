using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class PhoneNumber
    {
        public int Id {  get; set; }
        public string phone {  get; set; }
        public int PersonId {  get; set; }
        public Person? Person {  get; set; }
        public PhoneNumber() { }
        public PhoneNumber(string PhoneNo,int personId) 
        {
            this.phone = PhoneNo.Trim();
            PersonId = personId;
        }
    }
}
