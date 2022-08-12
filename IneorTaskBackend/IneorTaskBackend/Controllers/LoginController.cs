using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IneorTaskBackend.Interfaces;
using IneorTaskBackend.Model.Login;
using Microsoft.AspNetCore.Http;

namespace IneorTaskBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Attempts to login into a user account
        /// </summary>
        /// <param name="loginRequest">Login data</param>
        /// <returns>Data with access token</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _loginService.LoginAsync(loginRequest);
            if (loginResponse == null)
                return Unauthorized();
            return Ok(loginResponse);
        }

        /// <summary>
        /// Creates an account (unused - only used for preparing accounts)
        /// </summary>
        /// <param name="signupRequest">Signup data</param>
        [HttpPost]
        [Route("signup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Signup(LoginRequest signupRequest)
        {
            await _loginService.SignupAsync(signupRequest);
            return Ok();
        }
    }
}
