using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class PhoneNumber
    {
        public int Id {  get; set; }
        public required string phone {  get; set; }
        public int PersonId {  get; set; }
        public Person? Person {  get; set; }
    }
}
