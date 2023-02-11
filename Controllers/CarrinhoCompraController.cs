using EcommerceMVC.Models;
using EcommerceMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers {
    public class CarrinhoCompraController : Controller {
        //Injetando a instancia para o acesso dos produtos e o carrinho
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository produtoRepository, CarrinhoCompra carrinhoCompra) {
            _produtoRepository = produtoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
