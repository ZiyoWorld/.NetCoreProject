using Houzing2.Models.Domain;
using Houzing2.Models.DTO;
using Houzing2.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Houzing2.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationServise authService;
        UserManager<User> _userManager;
        public UserAuthenticationController(IUserAuthenticationServise authService, )
        {
            this.authService = authService;
        }
        /* We will create a user with admin rights, after that we are going
           to comment this method because we need only
           one user in this application 
           If you need other users ,you can implement this registration method with view
           I have create a complete tutorial for this, you can check the link in description box
          */
        public IActionResult Index()
        {
            return View(authService.Users.ToList());
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin()
        {
            var model = new RegistrationModel
            {
                Username = "admin",
                Email = "admin@gmail.com",
                FirstName = "Mirziyod",
                LastName = "Sunatillayev",
                Password = "Admin@123",
                ConfirmPassword = "Admin@123",
            };
            model.Role = "admin";
            var result = await this.authService.RegisterAsync(model);
            return Ok(result.Message);
            
            
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "user";
            var result = await this.authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index", "Home");   
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction("Login", "UserAuthentication");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction("Login", "UserAuthentication");
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await authService.ChangePasswordAsync(model, User.Identity.Name);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(ChangePassword));
        }

    }
}
