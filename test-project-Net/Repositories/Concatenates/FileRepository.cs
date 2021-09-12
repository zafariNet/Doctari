using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using test_project_Net.Domain;
using test_project_Net.Repositories.Interfaces;

namespace test_project_Net.Repositories.Concatenates
{
    public class FileRepository:IFileRepository
    {
        private readonly string _personDataSource;
        private readonly string _statesDataSource;
        private readonly FileDataSource _fileDataSource;

        public FileRepository()
        {
            _fileDataSource = new FileDataSource();
            _personDataSource = _fileDataSource.ReadPersonData();
            _statesDataSource = _fileDataSource.ReadStateData();
        }

        public List<State> GetAllStates()
        {
            var stateList = new List<State>();
            var states = Regex.Split(_statesDataSource, "\n|\r");
            foreach (var state in states.Where(x=>x!=""))
            {
                stateList.Add(new State(state.Split('*')[1], 
                    state.Split('*')[0]));
            }

            return stateList;
        }
        public List<Person> GetAllPersons()
        {
       
            var list = new List<List<string>>();
            var personData = new List<string>();

            foreach (var address in SplitAddressText(_personDataSource))
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

        public void AddNewState(string state)
        {
            _fileDataSource.WriteNewState(state);
        }
        private  string[] SplitAddressText(string data)
        {
            var addresses = Regex.Split(data, "\r\n|\r|\n");
            return addresses;
        }

        private List<Person> CreatePersonList(List<List<string>> persons)
        {
            var personList = new List<Person>();
            persons.ForEach(x =>
            {
                personList.Add(x.Count == 3 ? new Person(x[0], x[1], x[2].Split(' ')[1], x[2].Split(' ')[0]) :
                    new Person(x[0], x[1], "Invalid Address","Invalid Postal Code", false));
            });
            return personList;
        }
    }
}
