using System.Collections.Generic;
using System.Threading.Tasks;
using test_project_Net.Services.ViewModels;

namespace test_project_Net.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonView>> GetStateForAllPersonAsync();
    }
}
