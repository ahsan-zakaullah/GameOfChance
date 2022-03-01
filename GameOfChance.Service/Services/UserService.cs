using GameOfChance.Common;
using GameOfChance.Models;
using GameOfChance.Repository.IRepositories;
using GameOfChance.Service.IServices;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GameOfChance.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserAndRoleRepository _userAndRoleRepository;
        public UserService(IUserAndRoleRepository userAndRoleRepository)
        {
            _userAndRoleRepository = userAndRoleRepository;
        }

        public async Task<bool> CheckPasswordAsync(IdentityUser user, string? password)
        {
            return await _userAndRoleRepository.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateAndAssignRoleAsync(IdentityUser user, string roleName)
        {
            if (!await _userAndRoleRepository.RoleExistsAsync(roleName))
            {
                var roleResult = await _userAndRoleRepository.CreateRoleAsync(new IdentityRole(roleName));
                if (roleResult.Succeeded)
                {
                    return await _userAndRoleRepository.AddToRoleAsync(user, roleName);
                }
                throw new GameOfChanceException("Unable to Assign the role to user");
            }
            else
            {
                return await _userAndRoleRepository.AddToRoleAsync(user, roleName);
            }

        }

        public async Task<IdentityResult> CreateAsync(UserRegisterRequest model)
        {
            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            return await _userAndRoleRepository.CreateAsync(user, model.Password);
        }

        public async Task<IdentityUser> FindByNameAsync(string? userName)
        {
            return await _userAndRoleRepository.FindByNameAsync(userName);
        }

        public async Task<List<Claim>> Login(LoginRequest model)
        {
            var user = await _userAndRoleRepository.FindByNameAsync(model.Username);
            if (user != null && await _userAndRoleRepository.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userAndRoleRepository.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Actor, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                return authClaims;
            }
            throw new GameOfChanceException("Unable to login");
        }
    }
}
