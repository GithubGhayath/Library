using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (!value.Contains("@"))
                throw new Exception("Invalid email");

            Value = value;
        }
    }
}
