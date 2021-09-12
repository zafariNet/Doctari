using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_project_Net.Domain;
using test_project_Net.Domain.GeoCodes;
using test_project_Net.Services.ViewModels;

namespace test_project_Net.Services.Interfaces
{
    public interface IStateService
    {
        string GetState(GoogleResponseModel data);
        string GetStateFromFile(string postalCode);
        void AddStateToFile(List<PersonView> persons);
    }
}
