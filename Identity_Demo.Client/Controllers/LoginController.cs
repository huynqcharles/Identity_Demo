using Identity_Demo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;

namespace Identity_Demo.Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            // Convert registerUser to JSON
            var loginUserJSON = JsonConvert.SerializeObject(loginUser);

            // Convert to string content
            var stringContent = new StringContent(loginUserJSON, Encoding.UTF8, "application/json");

            // Send request POST to register API
            var response = await _httpClient.PostAsync($"https://localhost:7067/api/login", stringContent);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                HttpContext.Session.SetString("JWTToken", token);

                var responseToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = await response.Content.ReadAsStringAsync();
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWTToken");
            return RedirectToAction("Index", "Home");
        }
    }
}
