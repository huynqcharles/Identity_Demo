using Identity_Demo.API.Models;

namespace Identity_Demo.API.IServices
{
    public interface IRegisterService
    {
        Task<Response> RegisterAsync(RegisterUser registerUser, string role);
    }
}
