using EcommerceMVC.Models;
using EcommerceMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers {
    public class PedidoController : Controller {
        //Acessar e criar os pedidos
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra) {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        public IActionResult Checkout() {
            return View();  
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido) {
            return View();
        }
    }
}
