using EcommerceMVC.Models;
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

        //precisa receber o parametro do nome da categoria
        public IActionResult List(string categoria) {

            //Filtando pela categoria
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            //Retonar tudo
            if (string.IsNullOrEmpty(categoria)) {
                produtos = _produtoRepository.Produtos.OrderBy(l => l.ProdutoId);
                categoriaAtual = "Todos os produtos";
            } else {
                //LEGADO
                /*if (string.Equals("Estoicos", categoria, StringComparison.OrdinalIgnoreCase)) {
                    produtos = _produtoRepository.Produtos.Where(l => l.Categoria.CategoriaNome.Equals("Estoicos")).OrderBy(l => l.Nome);
                } else if (string.Equals("Manga", categoria, StringComparison.OrdinalIgnoreCase)) {
                    produtos = _produtoRepository.Produtos.Where(l => l.Categoria.CategoriaNome.Equals("Manga")).OrderBy(l => l.Nome);
                } else if (string.Equals("Suplementos", categoria, StringComparison.OrdinalIgnoreCase)) {
                    produtos = _produtoRepository.Produtos.Where(l => l.Categoria.CategoriaNome.Equals("Suplementos")).OrderBy(l => l.Nome);
                } else {
                    produtos = _produtoRepository.Produtos.Where(l => l.Categoria.CategoriaNome.Equals("404")).OrderBy(l => l.Nome);}*/

                //Consulta das categorias
                produtos = _produtoRepository.Produtos.Where(l => l.Categoria.CategoriaNome.Equals(categoria)).OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }
            var produtosListViewModel = new ProdutoListViewModel {
                Produto = produtos,
                CategoriaAtual = categoriaAtual
            };

            return View(produtosListViewModel);
        }

        public IActionResult Details(int produtoId) {
            var produto = _produtoRepository.Produtos.FirstOrDefault(l => l.ProdutoId == produtoId);
            return View(produto);
        }

        //Pesquisar produto pelo nome
        public ViewResult Search(string searchString) {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString)) {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Todos os Produtos";
            } else {
                produtos = _produtoRepository.Produtos.Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));
                if (produtos.Any())
                    categoriaAtual = "Produtos";
                else
                    categoriaAtual = "Nenhum produto foi encontrado";
            
            }
            return View("~/Views/Produto/List.cshtml", new ProdutoListViewModel{
                Produto = produtos,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
