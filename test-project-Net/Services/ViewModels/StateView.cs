using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_project_Net.Services.ViewModels
{
    public class StateView
    {
        public StateView(string name, string postalCode)
        {
            Name = name;
            PostalCode = postalCode;
        }
        public string Name { get; set; }
        public string PostalCode { get; set; }
    }
}
