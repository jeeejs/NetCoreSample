using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonMicroservice.DBContexts;
using PersonMicroservice.Models;

namespace PersonMicroservice.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _dbContext;

        public PersonRepository(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeletePerson(long personId)
        {
            var person = _dbContext.Persons.Find(personId);
            _dbContext.Persons.Remove(person);
            Save();
        }

        public Person GetPersonByID(long personId)
        {
            return _dbContext.Persons.Find(personId);
        }

        public IEnumerable<Person> GetPersons()
        {
            return _dbContext.Persons.ToList();
        }

        public void InsertPerson(Person person)
        {
            _dbContext.Add(person);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
            Save();
        }
    }
}
