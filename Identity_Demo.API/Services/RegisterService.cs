using Identity_Demo.API.IServices;
using Identity_Demo.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity_Demo.API.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Response> RegisterAsync(RegisterUser registerUser, string role)
        {
            // Check user is exists or not
            if (await _userManager.FindByEmailAsync(registerUser.Email) != null)
            {
                return new Response
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "This email is already exists!"
                };
            }
            else if (await _userManager.FindByNameAsync(registerUser.Username) != null)
            {
                return new Response
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "This username is already exists!"
                };
            }

            // Check password is matching with confirm password or not
            if (registerUser.Password != registerUser.ConfirmPassword)
            {
                return new Response
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "This password doesn't match with confirm password!"
                };
            }

            // Create an identity user
            IdentityUser identityUser = new()
            {
                UserName = registerUser.Username,
                Email = registerUser.Email
            };

            // Check if roles is exists or not
            if (await _roleManager.RoleExistsAsync(role))
            {
                // Add user to the database
                var result = await _userManager.CreateAsync(identityUser, registerUser.Password);

                // Check if register is fail
                if (!result.Succeeded)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        StatusCode = 500,
                        Message = "Register failed, something went wrong!"
                    };
                }

                // Add role to the user
                await _userManager.AddToRoleAsync(identityUser, role);
                return new Response
                {
                    IsSuccess = true,
                    StatusCode = 201,
                    Message = "Register successfully!"
                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = "This role doesn't exists!"
                };
            }
        }
    }
}
