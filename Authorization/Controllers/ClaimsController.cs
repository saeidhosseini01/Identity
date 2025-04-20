using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    public class ClaimsController : Controller
    {

        [Authorize]
        public IActionResult Index()
        {
            return View(User?.Claims);
        }
    }
}
