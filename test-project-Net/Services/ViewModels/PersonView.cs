using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_project_Net.Services.ViewModels
{
    public class PersonView
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public bool IsValid { get; set; }
    }
}
