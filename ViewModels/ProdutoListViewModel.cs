using EcommerceMVC.Models;

namespace EcommerceMVC.ViewModels {
    public class ProdutoListViewModel {

        //Definir lista de produtos
        public IEnumerable <Produto> Produto { get; set; }
        public string CategoriaAtual { get; set; }

    }
}
