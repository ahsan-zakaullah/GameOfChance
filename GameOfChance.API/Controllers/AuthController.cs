using GameOfChance.API.ActionFilters;
using GameOfChance.API.Extensions;
using GameOfChance.API.Validators;
using GameOfChance.Common;
using GameOfChance.Models;
using GameOfChance.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameOfChance.API.Controllers
{
    [AllowAnonymous, Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("register"), ValidateModel("model", typeof(UserRegisterValidator))]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest model)
        {
            var userExists = await _userService.FindByNameAsync(model.Username);
            if (userExists != null)
                return Conflict("User Already Exists..");

            var result = await _userService.CreateAsync(model);
            if (result.Succeeded)
            {
                // I am going to assign the role to user internally and every user will be considered as a admin. 
                // further we can pass the role from request and assign it to user.
                await _userService.CreateAndAssignRoleAsync(model.Map(), Constants.Admin);
                return Ok("User created successfully!");
            }
            return BadRequest(result.Errors?.FirstOrDefault()?.Description);

        }
        [HttpPost]
        [Route("login"), ValidateModel("model", typeof(LoginRequestValidator))]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var user = await _userService.FindByNameAsync(model.Username);
            if (user != null && await _userService.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = await _userService.Login(model);
                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return NotFound("Username or password incorrect.");
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
