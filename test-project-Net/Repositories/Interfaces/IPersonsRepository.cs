using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_project_Net.Domain.Models.Entities;

namespace test_project_Net.Repositories.Interfaces
{
    
    public interface IPersonsRepository
    {
        List<Person> GetAllPersons();
    }
}
