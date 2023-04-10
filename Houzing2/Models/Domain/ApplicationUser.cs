using Microsoft.AspNetCore.Identity;

namespace Houzing2.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }

    }
}
