using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Users.Dtos
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
