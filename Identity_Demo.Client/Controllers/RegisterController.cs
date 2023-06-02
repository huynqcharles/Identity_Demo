using Identity_Demo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Identity_Demo.Client.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _httpClient;
        public RegisterController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser, string role)
        {
            // Convert registerUser to JSON
            var registerUserJSON = JsonConvert.SerializeObject(registerUser);

            // Convert to string content
            var stringContent = new StringContent(registerUserJSON, Encoding.UTF8, "application/json");

            // Add role to queryString
            role = "User";
            var queryString = $"?role={role}";

            // Send request POST to register API
            var response = await _httpClient.PostAsync($"https://localhost:7067/api/register{queryString}", stringContent);
            
            ViewBag.Message = await response.Content.ReadAsStringAsync();
            return View();
        }
    }
}
