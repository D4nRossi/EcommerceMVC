using EcommerceMVC.Models;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Components {
    public class CarrinhoCompraResumo : ViewComponent {
        //Acessando o carrinho
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra) {
            _carrinhoCompra = carrinhoCompra;
        }

        //Metodo Invoke
        public IViewComponentResult Invoke() {
            //Itens a serem obtidos
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            //Instancia da ViewModel
            var carrinhoCompraViewModel = new CarrinhoCompraViewModel {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraViewModel);
        }
    }
}