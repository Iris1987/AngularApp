using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    //[Route("api/Login")] //maybeh?
    [Authorize]
    public class LoginController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            return Redirect("/Index");
        }


        //https://dotnetcoretutorials.com/2017/09/16/cookie-authentication-asp-net-core-2-0/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (LoginUser(loginVM.Username, loginVM.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginVM.Username)
            };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        private bool LoginUser(string username, string password)
        {
            //As an example. This method would go to our data store and validate that the combination is correct. 
            //For now just return true. 
            if (username == "admin" && password == "thematic")
                return true;
            else return false;
        }
    }
}