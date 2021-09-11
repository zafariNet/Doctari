using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_project_Net.Domain.Models.GeoCodes;
using test_project_Net.ExtraWebServices.Concatenates;
using test_project_Net.ExtraWebServices.Interfaces;
using test_project_Net.Repositories.Concatenates;
using test_project_Net.Repositories.Interfaces;
using test_project_Net.Services.Interfaces;
using test_project_Net.Services.ViewModels;

namespace test_project_Net.Services.Concatenates
{
    public class PersonService:IPersonService
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IGoogleService _googleService;

        public PersonService()
        {
            _personsRepository = new PersonRepository();
            _googleService = new GoogleService();
        }

        public async Task<List<PersonView>> GetEstateForAllPersonAsync()
        {
            var personList = new List<PersonView>();
            var persons = _personsRepository.GetAllPersons();
            try
            {

                foreach (var person in persons)
                {
                    var result =person.IsValid? await _googleService.GetGeoCodeAddressAsync(person.PostalCode):new Root(){Status = "Invalid Data"};
                        personList.Add(new PersonView
                        {
                            FullName = person.FullName,
                            PostalCode = person.PostalCode,
                            Address = person.Address,
                            IsValid = person.IsValid,
                            State = GetState(result)
                        });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return personList;
        }

        private string GetState(Root data)
        {
            if(data.Status=="OK")
                return data.Results[0].Address_Components.FirstOrDefault(x => x.Types.Contains("administrative_area_level_1"))?.Long_Name;
            if (data.Results?.Count == 0)
                return "State not found!";
            return data.Status;

        }
    }
}
