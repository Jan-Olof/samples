using AutoMapper;
using Samples.DomainLayer.Persons;
using System;
using System.Net.Mail;

namespace Samples.InfrastructureLayer.Persons
{
    /// <summary>
    /// Defines how to map persons using auto mapper.
    /// </summary>
    public class PersonMapping : Profile
    {
        public PersonMapping(DateTime now)
        {
            CreateMap<PersonDao, Person>()
               .ForMember(person => person.MailAddress, dest => dest.MapFrom(personDao => new MailAddress(personDao.MailAddress)))
               .ForMember(person => person.DateOfBirth, dest => dest.MapFrom(personDao => new BirthDate(personDao.DateOfBirth, now)))
               .ForMember(person => person.Name, dest => dest.MapFrom(personDao => new PersonsName(personDao.FirstName, personDao.LastName)));

            CreateMap<Person, PersonDao>()
                .ForMember(personDao => personDao.MailAddress, dest => dest.MapFrom(person => person.MailAddress.Address))
                .ForMember(personDao => personDao.DateOfBirth, dest => dest.MapFrom(person => person.DateOfBirth.Date))
                .ForMember(personDao => personDao.FirstName, dest => dest.MapFrom(person => person.Name.FirstName))
                .ForMember(personDao => personDao.LastName, dest => dest.MapFrom(person => person.Name.LastName));

            CreateMap<PersonDao, PersonDto>()
                .ForMember(person => person.Id, dest => dest.MapFrom(personDao => personDao.Id.ToString()));

            CreateMap<Person, PersonDto>()
                .ForMember(personDto => personDto.FirstName, dest => dest.MapFrom(person => person.Name.FirstName))
                .ForMember(personDto => personDto.LastName, dest => dest.MapFrom(person => person.Name.LastName))
                .ForMember(personDto => personDto.MailAddress, dest => dest.MapFrom(person => person.MailAddress.Address))
                .ForMember(personDto => personDto.Id, dest => dest.MapFrom(person => person.Id.ToString()))
                .ForMember(personDto => personDto.DateOfBirth, dest => dest.MapFrom(person => person.DateOfBirth.Date));

            CreateMap<PersonDto, Person>()
                .ForMember(person => person.Name, dest => dest.MapFrom(personDto => new PersonsName(personDto.FirstName, personDto.LastName)))
                .ForMember(person => person.MailAddress, dest => dest.MapFrom(personDto => new MailAddress(personDto.MailAddress)))
                .ForMember(person => person.Id, dest => dest.MapFrom(personDto => new Guid(personDto.Id)))
                .ForMember(person => person.DateOfBirth, dest => dest.MapFrom(personDto => new BirthDate(personDto.DateOfBirth, now)));

            CreateMap<CreatePersonDto, Person>()
                .ForMember(person => person.Name, dest => dest.MapFrom(createPersonDto => new PersonsName(createPersonDto.FirstName, createPersonDto.LastName)))
                .ForMember(person => person.MailAddress, dest => dest.MapFrom(createPersonDto => new MailAddress(createPersonDto.MailAddress)))
                .ForMember(person => person.DateOfBirth, dest => dest.MapFrom(createPersonDto => new BirthDate(createPersonDto.DateOfBirth, now)));
        }
    }
}