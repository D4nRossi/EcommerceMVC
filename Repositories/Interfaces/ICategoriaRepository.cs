using EcommerceMVC.Models;

namespace EcommerceMVC.Repositories.Interfaces {
    public interface ICategoriaRepository {

        //Contrato que sera implementado pelas classes concretas
        IEnumerable<Categoria> Categorias { get; } //Coleção de objetos categoria
    }
}
