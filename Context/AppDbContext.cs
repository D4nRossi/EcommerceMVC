using EcommerceMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Context {
    public class AppDbContext : IdentityDbContext<IdentityUser> {
        //Definir classes a serem mapeadas
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            //Carrega as informações necessárias para configurar o DbContext
        }



        //Definir propriedades DbSet
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }

    }
}
