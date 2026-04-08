using BCrypt.Net;
using Library.Application.Features.Users.Dtos;
using Library.Domain.Entities;
using Library.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Features.Users.Mappings
{
    public static class UserMappings
    {
        public static UserSummaryDto ToUserSummaryDto(this User user)
        {
            return new UserSummaryDto
            {
                FirstName = user.Person.FirstName,
                LastName = user.Person.LastName,
                City = user.Person.Address!.City,
                Gender = user.Person.Gender,
                Email = user.Person.Email!.Value
            };
        }

        public static UserDetailsDto ToUserDetailsDto(this User user,List<string>phoneNumbers)
        {
            return new UserDetailsDto
            {
                FirstName = user.Person.FirstName,
                LastName = user.Person.LastName,
                City = user.Person.Address!.City,
                Gender = user.Person.Gender,
                Email = user.Person.Email!.Value,
                CreateAt = user.Person.AuditTimestamp?.CreateAt??null,
                UpdateAt = user.Person.AuditTimestamp?.UpdateAt??null,
                ZipCode = user.Person.Address.ZipCode,
                Street= user.Person.Address.Street,
                PhoneNumbers= phoneNumbers
            };
        }
        public static Person ToPersonEntity(this CreateUserDto createUserDto)
        {
            return new Person(createUserDto.FirstName, createUserDto.LastName, createUserDto.Gender, new Address(createUserDto.City, createUserDto.Street, createUserDto.ZipCode), new Email(createUserDto.Email));
        }
        public static List<Domain.Entities.PhoneNumber> ToEntities(this CreateUserDto createUserDto, int PersonId)
        {
            var phoneNumbers = new List<Domain.Entities.PhoneNumber>();
            foreach (var phoneNumber in createUserDto.PhoneNumbers)
            {
                phoneNumbers.Add(new Domain.Entities.PhoneNumber(phoneNumber, PersonId));
            }
            return phoneNumbers;
        }

        public static User ToUserEntity(this CreateUserDto createUserDto,int PersonId)
        {
            return new User(PersonId,BCrypt.Net.BCrypt.HashPassword(createUserDto.Password), "User");
        }
    }
}
