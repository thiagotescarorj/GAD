using System.Security.Claims;

namespace Impacta.GAD.WebAPI.Extentions
{
    public static class ClaimsPrincipalExtentions
    {
        public static string GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static long GetUserId(this ClaimsPrincipal user)
        {
            return long.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
