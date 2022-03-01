using GameOfChance.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GameOfChance.Service.IServices
{
    public interface IUserService
    {
        Task<List<Claim>> Login(LoginRequest model);
        Task<IdentityUser> FindByNameAsync(string? userName);
        Task<bool> CheckPasswordAsync(IdentityUser user, string? password);
        Task<IdentityResult> CreateAsync(UserRegisterRequest user);
        Task<IdentityResult> CreateAndAssignRoleAsync(IdentityUser user, string roleName);
    }
}
