using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonMicroservice.Models;
using PersonMicroservice.Repository;

namespace PersonMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET: api/Person
        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personRepository.GetPersons();
            return new OkObjectResult(persons);
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var persons = _personRepository.GetPersonByID(id);
            return new OkObjectResult(persons);
        }

        // POST: api/Person
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            using (var scope = new TransactionScope())
            {
                _personRepository.InsertPerson(person);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
            }
        }

        // PUT: api/Person/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (person != null)
            {
                using (var scope = new TransactionScope())
                {
                    _personRepository.UpdatePerson(person);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personRepository.DeletePerson(id);
            return new OkResult();
        }
    }
}
