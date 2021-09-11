using System.Collections.Generic;
using System.Text.RegularExpressions;
using test_project_Net.Domain.Models.Entities;
using test_project_Net.Repositories.Interfaces;

namespace test_project_Net.Repositories.Concatenates
{
    public class PersonRepository:IPersonsRepository
    {
        private readonly string _dataSource;

        public PersonRepository()
        {
            var dataReader = new DataReader();
            _dataSource = dataReader.ReadData(); ;
        }

        public List<Person> GetAllPersons()
        {
       
            var list = new List<List<string>>();
            var personData = new List<string>();

            foreach (var address in SplitText(_dataSource))
            {
                if (address != "")
                {
                    personData.Add(address);
                }
                else
                {
                    list.Add(personData);
                    personData = new List<string>();
                }
            }

            
            return CreatePersonList(list);
        }
        private  string[] SplitText(string data)
        {
            var addresses = Regex.Split(data, "\r\n|\r|\n");
            return addresses;
        }

        private List<Person> CreatePersonList(List<List<string>> persons)
        {
            var personList = new List<Person>();
            persons.ForEach(x =>
            {
                personList.Add(x.Count == 3 ? new Person(x[0], x[1], x[2]) :
                    new Person(x[0], x[1], x[2], false));
            });
            return personList;
        }
    }
}
