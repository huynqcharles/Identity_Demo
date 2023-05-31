using Identity_Demo.API.IServices;
using Identity_Demo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Demo.API.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser, string role)
        {
            var result = await _registerService.RegisterAsync(registerUser, role);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
