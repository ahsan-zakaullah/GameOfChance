using Microsoft.AspNetCore.Identity;

namespace GameOfChance.Repository.IRepositories
{
    public interface IUserAndRoleRepository
    {
        Task<IdentityUser> FindByNameAsync(string? userName);
        Task<bool> RoleExistsAsync(string? roleName);
        Task<bool> CheckPasswordAsync(IdentityUser user, string? password);
        Task<IdentityResult> AddToRoleAsync(IdentityUser user, string? role);
        Task<IList<string>> GetRolesAsync(IdentityUser user);
        Task<IdentityResult> CreateAsync(IdentityUser user, string? password);
        Task<IdentityResult> CreateRoleAsync(IdentityRole role);
    }
}
