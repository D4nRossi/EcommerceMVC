using EcommerceMVC.Context;
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
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null) {
                carrinhoCompraItem = new CarrinhoCompraItem {
                    //Atribuindo Id criado ou obtido
                    CarrinhoCompraId = CarrinhoCompraId,
                    //Produto que quero incluir
                    Produto = produto,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            } else {
                //Se ele já existe é só incrementar
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }
    }
}
