using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Areas.Admin.Controllers {
    //Sempre definir a Area quando for usar
    [Area("Admin")]
    [Authorize]
    public class AdminController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
