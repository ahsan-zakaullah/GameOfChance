using System.Security.Claims;

namespace GameOfChance.API.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirstValue(ClaimTypes.Actor);
        }
        public static string GetUserName(this ClaimsPrincipal claims)
        {
            var result = claims.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(result))
            {
                return claims.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return result;
        }
    }
}
