using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_project_Net.Domain;
using test_project_Net.Domain.GeoCodes;
using test_project_Net.ExternalWebServices.Interfaces;
using test_project_Net.Repositories.Interfaces;
using test_project_Net.Services.Interfaces;
using test_project_Net.Services.ViewModels;

namespace test_project_Net.Services.Concatenates
{
    public class PersonService:IPersonService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IGoogleService _googleService;
        private readonly IStateService _stateService;

        public PersonService(IFileRepository fileRepository, IGoogleService googleService, IStateService stateService)
        {
            _fileRepository = fileRepository;
            _googleService = googleService;
            _stateService = stateService;

        }

        public async Task<List<PersonView>> GetStateForAllPersonAsync()
        {
            var personList = new List<PersonView>();
            try
            {
                var savedPersons = _fileRepository.GetAllPersons();
                foreach (var person in savedPersons)
                {
                    var state = _stateService.GetStateFromFile(person.PostalCode);
                    var root = new GoogleResponseModel();
                    if (state==null)
                     root= person.IsValid
                        ? await _googleService.GetGeoCodeAddressAsync($"{person.PostalCode} {person.City}")
                        : new GoogleResponseModel(){Status = "Invalid"};
                    var personView = new PersonView
                    {
                        FullName = person.FullName,
                        PostalCode = person.PostalCode,
                        City = person.City,
                        Address = person.Address,
                        IsValid = person.IsValid,
                        State = state ?? _stateService.GetState(root),
                        PersonDataStatus = state==null?PersonDataStatus.StateComesFromGoogle:PersonDataStatus.SateComesFromFile

                    };
                    personList.Add(personView);
                }

                _stateService.AddStateToFile(personList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return personList;
        }

      
    }
}
