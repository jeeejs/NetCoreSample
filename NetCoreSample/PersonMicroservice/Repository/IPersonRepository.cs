using PersonMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonMicroservice.Repository
{
    public interface IPersonRepository
    {
        List<Person> GetPersons();
        Person GetPersonByID(long personId);
        Person GetPersonByEmail(string email);
        void InsertPerson(Person person);
        void DeletePerson(long personId);
        void UpdatePerson(Person person);
        PersonAuth Login(Person person);
        void Save();
    }
}
