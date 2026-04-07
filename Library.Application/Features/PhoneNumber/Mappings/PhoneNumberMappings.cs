using Library.Application.Features.PhoneNumber.Dtos;

namespace Library.Application.Features.PhoneNumber.Mappings
{
    public static class PhoneNumberMappings
    {
        public static Library.Domain.Entities.PhoneNumber ToEntity(this CreatePhoneNumberDto phoneNumberDto)
        {
            return new Domain.Entities.PhoneNumber 
            {
                PersonId = phoneNumberDto.PersonId,
                phone=phoneNumberDto.PhoneNumber,
            };
        }

        public static PhoneNumberDto ToDto(this Library.Domain.Entities.PhoneNumber phoneNumber)
        {
            return new PhoneNumberDto
            {
                Email = phoneNumber.Person!.Email!.Value,
                Owner = phoneNumber.Person.FirstName+" " + phoneNumber.Person.LastName,
                PhoneNumbers = phoneNumber.phone 
            };
        }
    }
}
