using EcommerceMVC.Context;
using EcommerceMVC.Models;
using EcommerceMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Repositories {
    public class ProdutoRepository : IProdutoRepository {

        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Produto> Produtos => _context.Produtos.Include(c => c.Categoria);

        public IEnumerable<Produto> ProdutosPreferidos => _context.Produtos.Where(l => l.IsProdutoPreferido).Include(c => c.Categoria);

        public Produto GetProdutoById(int produtoId) {
            return _context.Produtos.FirstOrDefault(c => c.ProdutoId == produtoId);
        }
    }
}
