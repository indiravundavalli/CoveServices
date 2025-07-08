using CS.Data.Repository;
using CS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CoveServicesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepo;
        private readonly ITokenRepository tokenRepo;

        public AuthController(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            userRepo = userRepository;
            tokenRepo = tokenRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Login login)
        {
            // Check if user is authenticated
            // Check username and password
            var user = await userRepo.AuthenticateAsync(
                login.Username, login.Password);

            if (user != null)
            {
                // Generate a JWT Token
                var token = await tokenRepo.CreateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect.");
        }
    }
}
