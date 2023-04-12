using Houzing2.Models.Domain;
using Houzing2.Models.DTO;
using Houzing2.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Houzing2.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationServise authService;

        public UserAuthenticationController(IUserAuthenticationServise authService)
        {
            this.authService = authService;
        }
        /* We will create a user with admin rights, after that we are going
           to comment this method because we need only
           one user in this application 
           If you need other users ,you can implement this registration method with view
           I have create a complete tutorial for this, you can check the link in description box
          */



        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegistrationModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        RegistrationModel user = await authService.RegisterAsync(model)
        //        if (user == null)
        //        {
        //            // добавляем пользователя в бд
        //            authService.RegisterAsync.Add(new RegistrationModel { Email = model.Email, Password = model.Password });
        //            await db.SaveChangesAsync();

        //            await Authenticate(model.Email); // аутентификация

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //    }
        //    return View(model);
        //}


        //var model = new RegistrationModel
        //{
        //    Email = "admin@gmail.com",
        //    Username = "admin",
        //    Name = "Mirziyod",
        //    Password = "Admin@123",
        //    PasswordConfirm = "Admin@123",
        //    Role = "Admin"
        //};
        // if you want to register with user , Change Role="User"
        //var result = await authService.RegisterAsync(model);
        //return Ok(result.Message);

        //[HttpGet]
        public IActionResult Index()
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
                return RedirectToAction("Index", "UserAuthentication");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
