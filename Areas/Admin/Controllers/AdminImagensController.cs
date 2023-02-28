using EcommerceMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EcommerceMVC.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller {

        //Obter o nome da pasta onde salvar os arquivos
        private readonly ConfigurationImagens _myConfig;
        //Info do ambiente onde a aplicação esta rodando
        private readonly IWebHostEnvironment _hostingEnvironment;

        //CTT injetando as duas instancias
        public AdminImagensController(IWebHostEnvironment hostEnvironment, IOptions<ConfigurationImagens> myConfiguration) {
            _hostingEnvironment = hostEnvironment;
            _myConfig = myConfiguration.Value;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
