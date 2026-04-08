using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Users.Dtos
{
    public class UserDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public string Email { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public DateTime? CreateAt {  get; set; }
        public DateTime? UpdateAt {  get; set; }
    }
}
