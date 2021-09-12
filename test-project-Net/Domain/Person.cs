namespace test_project_Net.Domain
{
    public class Person
    {
        public Person(string fullName,string address,string city,string postalCode,bool isValid=true)
        {
            FullName = fullName;
            Address = address;
            PostalCode = postalCode;
            City = city;
            IsValid = isValid;
        }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public bool IsValid { get; }
    }
}
