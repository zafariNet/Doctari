using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using test_project_Net.ExtraWebServices.Concatenates;
using test_project_Net.Repositories.Concatenates;
using test_project_Net.Services.Concatenates;
using test_project_Net.Services.Interfaces;
using test_project_Net.Services.ViewModels;

namespace test_project_Net
{
    /// <summary>
    /// start class of test project
    /// </summary>
    class Program
    {

        /// <summary>
        /// use DataReader to get content
        /// and display with console
        /// </summary>
        static async Task Main(string[] args)
        {

            var personService = new PersonService();
            var results = await GetData();

            foreach (var person in results)
            {
                Console.WriteLine($"Name : {person.FullName}");
                Console.WriteLine($"Address : {person.Address}");
                Console.WriteLine($"Postal Code : {person.PostalCode}");
                Console.WriteLine($"Is Valid : {person.IsValid}");
                Console.WriteLine($"State : {person.State}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        public static async Task<List<PersonView>> GetData()
        {
            IPersonService personService= new PersonService();
            var result = await personService.GetEstateForAllPersonAsync();
            return result;
        }
       
    }
}
