using System;
using PersonMicroservice.Controllers;
using PersonMicroservice.Repository;
using PersonMicroservice.Models;
using PersonMicroservice.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions.Ordering;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]
[assembly: TestCollectionOrderer("Xunit.Extensions.Ordering.CollectionOrderer", "Xunit.Extensions.Ordering")]

namespace PersonMicroservice.Test
{
    [Collection("Sequential")]
    public class PersonControllerTest
    {
        PersonRepository _personRepository;
        private Person _person = new Person();
        public PersonControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=PersonsDB;User ID=sa;Password=123;MultipleActiveResultSets=true;");

            var context = new PersonContext(optionsBuilder.Options);
            _personRepository = new PersonRepository(context);
            
            _person.Email = "XXXXXXXXXXX@XXXXXXXXXXX.XXX";
            _person.Name = "TESTE XXXXXXXXXXXXXXX";
            _person.Password = "XXXXXXXXXXXXXXXXX";
        }

        private void CleanTester()
        {
            var resp = _personRepository.GetPersonByEmail(_person.Email);
            while(resp != null)
            {
                _personRepository.DeletePerson(resp.Id);
            }
        }

        [Fact, Order(1)]
        public void CommunicationDb()
        {
            var resp = _personRepository.GetPersons();

            Assert.NotNull(resp);
        }

        [Fact, Order(2)]
        public void GetPersons()
        {
            var resp = _personRepository.GetPersons();

            Assert.NotNull(resp);
        }

        [Fact, Order(3)]
        public void InsertPerson()
        {
            CleanTester();
            _personRepository.InsertPerson(_person);
            var resp = _personRepository.GetPersonByEmail(_person.Email);
      
            Assert.NotNull(resp);
        }

        [Fact, Order(4)]
        public void UpdatePerson()
        {
            _person = _personRepository.GetPersonByEmail(_person.Email);
            string newName = "TESTE XXXXXXXXXXXXXXXYYYYYY";
            _person.Name = newName;
            _personRepository.UpdatePerson(_person);
            var resp = _personRepository.GetPersonByID(_person.Id);           

            Assert.Equal(resp.Name, newName);
        }

        [Fact, Order(5)]
        public void LoginPerson()
        {
            var resp = _personRepository.Login(_person);

            Assert.True(resp.Authenticated);
        }

        [Fact, Order(6)]
        public void DeletePerson()
        {
            _person = _personRepository.GetPersonByEmail(_person.Email);
            _personRepository.DeletePerson(_person.Id);
            var resp = _personRepository.GetPersonByID(_person.Id);

            Assert.Null(resp);
        }
    }
}
