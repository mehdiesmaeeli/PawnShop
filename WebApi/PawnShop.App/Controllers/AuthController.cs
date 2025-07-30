using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using PawnShop.App.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using PawnShop.App.Common.Dtos;
using PawnShop.App.Common.Statics;

namespace PawnShop.App.Controllers
{
    public class AuthController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto modelDto)
        {
            var user = new ApplicationUser { UserName = modelDto.Phone, Email = modelDto.Phone };
            var result = await _userManager.CreateAsync(user, modelDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, AppRoles.Customer);
                await _userManager.AddClaimAsync(user, new Claim("RegisteredAt", DateTime.UtcNow.ToString("o")));
                await _userManager.AddClaimAsync(user, new Claim("AccessLevel", "Basic"));
                return ApiOk("User registered successfully");
            }
            var errors = result.Errors.Select(e => e.Description).ToList();
            return ApiError("Registration failed", errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto modelDto)
        {
            var user = await _userManager.FindByEmailAsync(modelDto.Email);
            if (user == null)
                return ApiUnauthorized("کاربری با این ایمیل پیدا نشد.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, modelDto.Password);
            if (!isPasswordValid)
                return ApiUnauthorized("رمز عبور اشتباه است.");

            var token = await GenerateJwtToken(user);
            return ApiOk(token, "Login successful");
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            }
            ;

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.AddRange(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}