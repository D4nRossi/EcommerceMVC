using EcommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Context {
    public class AppDbContext : DbContext {
        //Definir classes a serem mapeadas
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            //Carrega as informações necessárias para configurar o DbContext
        }

        //Definir propriedades DbSet
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    }
}
