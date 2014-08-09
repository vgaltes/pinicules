using Microsoft.AspNet.Identity.EntityFramework;

namespace Pinicules.Presentation.Identity
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("IdentityConnection")
        {
        }
    }
}