using EcommerceMVC.Repositories.Interfaces;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EcommerceMVC.Controllers {
    public class ProdutoController : Controller {

        //Injetando acesso ao BD pelo repository
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        public IActionResult List() {
            //retornar uma lista de produtos
            //var produtos = _produtoRepository.Produtos;

            //retornando o obj para view
            //return View(produtos);

            //Usando as ViewModels
            var produtosListViewModel = new ProdutoListViewModel();
            produtosListViewModel.Produtos = _produtoRepository.Produtos;
            produtosListViewModel.CategoriaAtual = "Categoria Atual";

            return View(produtosListViewModel);

        }
    }
}
