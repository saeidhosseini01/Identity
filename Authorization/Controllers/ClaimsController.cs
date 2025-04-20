using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    public class ClaimsController : Controller
    {

  
        public IActionResult Index()
        {
            var s = User?.Claims;
            return View(User?.Claims);
        }
    }
}
