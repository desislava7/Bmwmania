using Microsoft.AspNetCore.Identity;

namespace Bmwmania.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Reservations> Reservations { get; set; }
    }
}
