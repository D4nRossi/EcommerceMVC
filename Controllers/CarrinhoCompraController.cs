using EcommerceMVC.Models;
using EcommerceMVC.Repositories.Interfaces;
using EcommerceMVC.ViewModels;
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
            //Itens a serem obtidos
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;
            //Instancia da ViewModel
            var carrinhoCompraVM = new CarrinhoCompraViewModel {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int produtoId) {
            //Retorno do primeiro elemento da sequencia, ou se não existir, um padrão
            var produtoSelecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produtoSelecionado != null) {
                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverItemNoCarrinhoCompra(int produtoId) {
            //Retorno do primeiro elemento da sequencia, ou se não existir, um padrão
            var produtoSelecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produtoSelecionado != null) {
                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
