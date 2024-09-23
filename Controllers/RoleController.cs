using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.ViewModels.IdentityViewModels;

namespace WebApplication1.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public async Task<IActionResult> Add(RoleViewModel model)
        {
            if(!ModelState.IsValid)
                return View("Index",await roleManager.Roles.ToListAsync());
            if(await roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name", "Role exists already!!");
                return View("Index" , await roleManager.Roles.ToListAsync());
            }
            await roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
            return RedirectToAction(nameof(Index));
        }
    }
}
