using test_project_Net.Domain.GeoCodes;

namespace test_project_Net.Services.ViewModels
{
    public class PersonView
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsValid { get; set; }
        public PersonDataStatus PersonDataStatus { get; set; }
    }
}
