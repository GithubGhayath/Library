using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.PhoneNumber.Dtos
{
    public class CreatePhoneNumberDto
    {
        public int PersonId {  get; set; }
        public string PhoneNumber { get; set; }
    }
}
