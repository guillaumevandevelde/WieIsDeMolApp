using System.Security.Claims;
using Auth0.AspNetCore.Authentication;
using DeMol.App.Services;
using DeMol.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeMol.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        public AccountController(
            
            UserService userService)
            
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = "/")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action(nameof(HandleCallback), new { returnUrl }))
                .Build();

            return Challenge(authenticationProperties, Auth0Constants.AuthenticationScheme);
        }
        
        [HttpGet]
        public async Task<IActionResult> HandleCallback(string returnUrl = "/")
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = User.Identity?.Name;

            await _userService.CreateUserAsync(new ApplicationUser()
            {
                Name = name,
                Email = email,
            });

            return LocalRedirect(returnUrl);
        }

        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be whitelisted in 
                .WithRedirectUri(Url.Action("Index", "Home"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }



        /// <summary>
        /// This is just a helper action to enable you to easily see all claims related to a user. It helps when debugging your
        /// application to see the in claims populated from the Auth0 ID Token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
