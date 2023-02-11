using EcommerceMVC.Models;
using EcommerceMVC.Repositories.Interfaces;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcommerceMVC.Controllers {
    public class HomeController : Controller {

        //Instancia do repositorio de produtos
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index() {
            var homeViewModel = new HomeViewModel {
                //Produtos obtidos pelo repositorio
                ProdutosPreferidos = _produtoRepository.ProdutosPreferidos
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}