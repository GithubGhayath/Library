using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public ICollection<Fine> Fines { get; set; } = new List<Fine>();
        private PaymentMethod() { }
        public PaymentMethod(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
