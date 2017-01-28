using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileResults.Web.Models;

namespace AgileResults.Web.Services
{
    public class FakeRepository : IRepository
    {
        private readonly List<Person> _people = new List<Person>();

        public FakeRepository()
        {                
        }


        public async Task<Guid> AddPerson(Person person)
        {
            person.PersonId = Guid.NewGuid();
            await Task.Run(() => _people.Add(person));
            return person.PersonId;
        }

        public async Task<Person> GetPerson(Guid personId)
        {
            var person = _people.FirstOrDefault(x => x.PersonId == personId);
            if (person == null)
            {
                throw new Exception("Person not found");
            }

            return await Task.Run(() => person);
        }
    }
}
