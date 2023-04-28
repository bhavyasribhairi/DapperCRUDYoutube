using DapperDemoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoData.Repository
{
    public interface IPersonRepository
    {
        public Task<bool> AddPerson(Person person);

        public Task<bool> UpdatePerson(int id,Person person);

        public Task<bool> DeletePersonById(int id);

        public Task<Person> GetPersonById(int id);

        public Task<IEnumerable<Person>> GetPeople();


    }
}
