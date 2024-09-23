using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.ViewModels.IdentityViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) 
        {           
            if (!ModelState.IsValid)
                return View(model);
            if (await userManager.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", "This email exists already");
                return View(model);
            }
            var appUser = new ApplicationUser();
            appUser.Email = model.Email;
            appUser.UserName = model.UserName;
            var result = await userManager.CreateAsync(appUser, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View(model);
            }
             await signInManager.SignInAsync(appUser, false);
             return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            var appUser = await userManager.FindByNameAsync(model.UserName);
            if (appUser is null || await userManager.CheckPasswordAsync(appUser,model.Password))
            {
                ModelState.AddModelError("UserName", "Name or password is incorrect");
                return View(model);
            }
            await signInManager.SignInAsync(appUser, model.RememberMe);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
