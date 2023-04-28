using DapperDemoData.Models;
using DapperDemoData.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await personRepository.GetPeople();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await personRepository.GetPersonById(id);
            if(person == null)
            {
                return BadRequest("Person not exists");
            }
            return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async  Task<bool> Post([FromBody] Person person)
        {

           return await personRepository.AddPerson(person)? true:false;

        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Person person)
        {
            return await personRepository.UpdatePerson(id,person)?true:false;
            
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
           return await personRepository.DeletePersonById(id)? true:false;


        }
    }
}
