namespace Presentation.Models
{
    public class UpdateProfileRequestForm
    {
        public String ProfileId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
    }
}
