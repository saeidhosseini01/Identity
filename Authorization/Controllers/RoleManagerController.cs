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
    }
}
