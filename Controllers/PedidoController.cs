using EcommerceMVC.Models;
using EcommerceMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EcommerceMVC.Controllers {
    public class PedidoController : Controller {
        //Acessar e criar os pedidos
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra) {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Checkout() {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Pedido pedido) {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            //Obter os itens do carrinho
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = items;

            //Verificar se existem itens de pedido
            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0) {
                ModelState.AddModelError("", "Seu carrinho esta vazio...");
            }

            //Calcular o total de itens e preço
            foreach (var item in items) {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Produto.Preco * item.Quantidade);
            }

            //Atribuir os valores ao pedido
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal = precoTotalPedido;

            //Validando os dados do pedido
            if (ModelState.IsValid) {
                //Cria o pedido e os detalhes
                _pedidoRepository.CriarPedido(pedido);
                //Definindo mensagem ao cliente
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();
                //Limpar o carrinho depois do pedido
                _carrinhoCompra.LimparCarrinho();
                //Exibindo a view com dados do cliente e do pedido
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
            return View(pedido);

        }
    }
}
