using BlogT53.Core.Domain.Identity;
using BlogT53.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogT53.Api.Controllers.AdninApi
{
    [Route("api/admin/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResult<AuthenticatedResult>> Login([FromBody] LoginRequest request)
        {
            // authen
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null || !user.IsActive || user.LockoutEnabled)
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, true);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            // author
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var accessToken = "";
            var refreshToken = "";

            return Ok(new AuthenticatedResult()
            {
                Token = "",
                RefreshToken = ""
            });
        }
    }
}