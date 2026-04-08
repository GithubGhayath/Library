using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Users.Dtos
{
    public class UserSummaryDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? City { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
    }
}
