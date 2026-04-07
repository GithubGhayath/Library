using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.PhoneNumber.Dtos
{
    public class PhoneNumberDto
    {
        public string Owner {  get; set; }
        public string PhoneNumbers {  get; set; }
        public string? Email {  get; set; }
    }
}
