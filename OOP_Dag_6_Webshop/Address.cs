namespace OOP_Dag_6_Webshop
{
    public class Address
    {
        public string StreetName { get; set; }
        public int StreetNumber{ get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public Address() { }
        public Address(string streetName, int streetNumber, string city, int postalCode, string country)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
        public override string ToString()
        {
            return $"{StreetName} {StreetNumber} {City} {PostalCode} {Country}";
        }
    }
}