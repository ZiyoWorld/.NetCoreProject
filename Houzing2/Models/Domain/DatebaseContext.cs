

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Houzing2.Models.Domain
{
    public class DatebaseContext: IdentityDbContext<ApplicationUser>
    {
       public DatebaseContext(DbContextOptions<DatebaseContext> options) : base(options)
        {

        }
    }
}
