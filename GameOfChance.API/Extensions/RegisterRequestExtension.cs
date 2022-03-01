using GameOfChance.Models;
using Microsoft.AspNetCore.Identity;

namespace GameOfChance.API.Extensions
{
    public static class RegisterRequestExtension
    {
        public static IdentityUser Map(this UserRegisterRequest source)
        {
            return new IdentityUser
            {
                Email = source.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = source.Username
            };

        }
    }
}
