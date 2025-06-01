namespace Presentation.Entities
{
    public class AddressEntity
    {
        public string Id { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public ICollection<ProfileEntity> Profiles { get; set;} = [];

    }
}
