using EcommerceMVC.Models;

namespace EcommerceMVC.Repositories.Interfaces {
    public interface IProdutoRepository {

        //Retorno de todos os produtos
        IEnumerable<Produto> Produtos { get; }

        //Só os preferidos
        IEnumerable<Produto> ProdutosPreferidos { get; }

        //Pelo Id
        Produto GetProdutoById(int produtoId);

    }
}
