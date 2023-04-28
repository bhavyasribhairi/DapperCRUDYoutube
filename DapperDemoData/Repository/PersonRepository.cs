using DapperDemoData.Data;
using DapperDemoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoData.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDataAccess db;

        public PersonRepository(IDataAccess db)
        {
            this.db = db;
        }

         async Task<bool> IPersonRepository.AddPerson(Person person)
        {
            try
            {
                var query = "insert into Person values(@Name, @Email)";
                await db.SaveData(query, new { Name = person.Name, Email = person.Email });
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        async Task<bool> IPersonRepository.DeletePersonById(int id)
        {
            try
            {
                var query = "delete from Person where Id=@Id";
                await db.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        async Task<IEnumerable<Person>> IPersonRepository.GetPeople()
        {
            string query = "Select * from Person";
            return await db.GetData<Person,dynamic>(query, new { });
        }

        async Task<Person> IPersonRepository.GetPersonById(int id)
        {
            string query = "Select * from Person where Id=@Id";
            var person= await db.GetData<Person, dynamic>(query, new {Id=id });
            return person.FirstOrDefault();
        }

        async Task<bool> IPersonRepository.UpdatePerson(int id,Person person)
        {
            try
            {
                var query = "Update Person set name=@Name, email=@Email where Id=@Id";
                await db.SaveData(query, new { Name = person.Name, Email = person.Email, Id=id });
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
