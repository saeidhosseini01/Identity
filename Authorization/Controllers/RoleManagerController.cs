using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> role;

        public RoleManagerController(RoleManager<IdentityRole> role)
        {
            this.role = role;
        }
        public IActionResult Index()
        {
            var roles=role.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name) {
            if (!role.RoleExistsAsync(name).Result)
            {

          var res=  role.CreateAsync(new IdentityRole (name)).Result;
            }
            return RedirectToAction("Index");
        }
    }
}
