using Microsoft.AspNetCore.Identity;

namespace Impacta.GAD.Domain.Identity
{
    public class Role : IdentityRole<long>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
