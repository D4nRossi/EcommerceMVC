using EcommerceMVC.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceMVC.Models {
    [Table("CarrinhoCompra")]
    public class CarrinhoCompra {

        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context) {
            _context = context;
        }

        [Key]
        public string CarrinhoCompraId { get; set; }
        //Lista do carrinho
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        public static CarrinhoCompra GetCarrinho(IServiceProvider services) {
            //Define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;//se não for nulo, retorna uma sessão
            //Obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();
            //Obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            //Atribui o Id do carrinho na session
            session.SetString("CarrinhoId", carrinhoId);
            //Retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context) {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Produto produto) {
            //Verificação se item ja esta no carrinho
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null) {
                carrinhoCompraItem = new CarrinhoCompraItem {
                    //Atribuindo Id criado ou obtido
                    CarrinhoCompraId = CarrinhoCompraId,
                    //Produto que quero incluir
                    Produto = produto,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
            } else {
                //Se ele já existe é só incrementar
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Produto produto) {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null) {
                if(carrinhoCompraItem.Quantidade > 1) {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                } else {
                    _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens() {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoCompraItems
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Produto)
                .ToList());
        }

        public void LimparCarrinho() {
            //Achar o carrinho que quero excluir
            var carrinhoItens = _context.CarrinhoCompraItems
                .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);
            //Removendo todas as entidades
            _context.CarrinhoCompraItems.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal() {
            var total = _context.CarrinhoCompraItems
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Produto.Preco * c.Quantidade)
                .Sum();
            return total;
        }
    }
}
