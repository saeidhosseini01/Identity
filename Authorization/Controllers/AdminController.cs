using Authorization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{



    public class AdminController : Controller
    {
        private UserManager<AppUser> UserManager;
        public AdminController(UserManager<AppUser> userManager )
        {
                UserManager = userManager;
        }
        public IActionResult Index()
        {
            var user=UserManager.Users.ToList();

            return View(user);
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(CreateModel User)
        {
            if(ModelState.IsValid) 
            {
                AppUser user = new AppUser{
                Email = User.Email,
                UserName=User.userName 
                };
                IdentityResult result = UserManager.CreateAsync(user,User.Password).Result;
                if(result.Succeeded)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    foreach (IdentityError  error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(User);
        }
    }
}
