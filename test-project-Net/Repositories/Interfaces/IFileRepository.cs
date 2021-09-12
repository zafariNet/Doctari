using System.Collections.Generic;
using test_project_Net.Domain;

namespace test_project_Net.Repositories.Interfaces
{
    
    public interface IFileRepository
    {
        List<Person> GetAllPersons();
        List<State> GetAllStates();
        void AddNewState(string state);
    }
}
