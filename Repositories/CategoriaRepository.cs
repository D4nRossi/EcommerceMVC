using EcommerceMVC.Context;
using EcommerceMVC.Models;
using EcommerceMVC.Repositories.Interfaces;

namespace EcommerceMVC.Repositories {
    public class CategoriaRepository : ICategoriaRepository{

        //Variavel para leitura do BD
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
