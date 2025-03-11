using Books.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email,string password)
        {
            try
            {
                var jwt = await _authService.Authenticate(email, password);
                return Ok(new { Token = jwt });
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
            
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(string name,string email, string password)
        {
            try
            {
                var jwt = await _authService.Register(name, email, password);
                return Ok(new { Token = jwt });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
