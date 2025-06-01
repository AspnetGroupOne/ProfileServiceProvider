using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Entities
{
    public class ProfileEntity
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;


        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; } = null!;
        public AddressEntity Address { get; set; } = null!;
     
    }
}
