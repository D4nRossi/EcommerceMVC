using EcommerceMVC.Models;

namespace EcommerceMVC.ViewModels {
    public class ProdutoListViewModel {

        //Definir lista de produtos
        public IEnumerable <Produto> Produtos { get; set; }
        public string CategoriaAtual { get; set; }

    }
}
