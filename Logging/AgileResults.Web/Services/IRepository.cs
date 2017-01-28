using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileResults.Web.Models;

namespace AgileResults.Web.Services
{
    public interface IRepository
    {
        Task<Guid> AddPerson(Person person);
        Task<Person> GetPerson(Guid personId);
    }
}
