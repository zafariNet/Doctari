using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project_Net.Domain.Models.Entities
{
    public class Person
    {
        public Person(string fullName,string address,string postalCode,bool isValid=true)
        {
            FullName = fullName;
            Address = address;
            PostalCode = postalCode;
            IsValid = isValid;
        }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public bool IsValid { get; }
    }
}
