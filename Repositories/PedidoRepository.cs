using EcommerceMVC.Context;
using EcommerceMVC.Models;
using EcommerceMVC.Repositories.Interfaces;

namespace EcommerceMVC.Repositories {
    public class PedidoRepository : IPedidoRepository {

        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra) {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido) {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach (var carrinhoItem in carrinhoCompraItens) {
                var pedidoDetail = new PedidoDetalhe() {
                    Quantidade = carrinhoItem.Quantidade,
                    ProdutoId = carrinhoItem.Produto.ProdutoId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Produto.Preco
                };
                _appDbContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
