using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using test_project_Net.Domain;
using test_project_Net.Domain.GeoCodes;
using test_project_Net.Repositories.Interfaces;
using test_project_Net.Services.Interfaces;
using test_project_Net.Services.ViewModels;

namespace test_project_Net.Services.Concatenates
{
    public class StateService:IStateService
    {
        private readonly IFileRepository _fileRepository;
        private readonly List<State> _states;
        public StateService(IFileRepository fileRepository,IMapper mapper)
        {
            _fileRepository = fileRepository;

            _states = _fileRepository.GetAllStates();
        }

        public string GetState(GoogleResponseModel data)
        {
            if (data.Status == "OK")
                return data.Results[0].Address_Components
                    .FirstOrDefault(x => x.Types.Contains("administrative_area_level_1"))?.Long_Name;
            if (data.Status == "Invalid")
                return "Person Data is Invalid !";
            if (data.Results?.Count == 0)
                return "State not found!";
            return data.Status;

        }

        public string GetStateFromFile(string postalCode)
        {
            var state = _states.FirstOrDefault(x => x.PostalCode == postalCode);
            return state?.Name;
        }

        public void AddStateToFile(List<PersonView> persons)
        {
            var validPersonState = persons.Where(x => x.IsValid );
            foreach (var person in validPersonState)
            {
                if (person.PersonDataStatus == PersonDataStatus.StateComesFromGoogle)
                    _fileRepository.AddNewState($"{person.PostalCode}*{person.State}");
            }

        }
    }
}
