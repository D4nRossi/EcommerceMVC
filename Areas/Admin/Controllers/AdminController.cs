using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel;

namespace EcommerceMVC.Areas.Admin.Controllers {
    //Sempre definir a Area quando for usar
    [Area("Admin")]
    [Authorize("Admin")]//Apenas admins podem acessar
    public class AdminController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}


