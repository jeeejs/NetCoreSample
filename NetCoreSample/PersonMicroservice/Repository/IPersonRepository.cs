using PersonMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonMicroservice.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
        Person GetPersonByID(long personId);
        void InsertPerson(Person person);
        void DeletePerson(long personId);
        void UpdatePerson(Person person);
        void Save();
    }
}
