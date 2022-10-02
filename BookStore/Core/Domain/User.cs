using Microsoft.AspNetCore.Identity;

namespace BookStore.Core.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
