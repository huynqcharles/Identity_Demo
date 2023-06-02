using Identity_Demo.Shared.Models;

namespace Identity_Demo.API.IServices
{
    public interface ILoginService
    {
        Task<Response> LoginAsync(LoginUser loginUser);
    }
}
