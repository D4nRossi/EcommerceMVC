using EcommerceMVC.Models;

namespace EcommerceMVC.ViewModels {
    public class HomeViewModel {

        //Exibir os produtos preferidos
        public IEnumerable<Produto> ProdutosPreferidos { get; set; }
    }
}
