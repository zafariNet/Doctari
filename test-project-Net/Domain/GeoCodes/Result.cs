using System.Collections.Generic;
using test_project_Net.Domain.GeoCodes;

namespace test_project_Net.Domain.Models.GeoCodes
{
    public class Result
    {
        public List<AddressComponent> Address_Components { get; set; }
        public string Formatted_Address { get; set; }
        public Geometry Geometry { get; set; }
        public string Place_Id { get; set; }
        public List<string> Types { get; set; }
    }
}
