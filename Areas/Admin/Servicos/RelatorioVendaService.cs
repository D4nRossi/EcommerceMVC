using EcommerceMVC.Context;
using EcommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Areas.Admin.Servicos {
    public class RelatorioVendaService {

        private readonly AppDbContext _context;

        public RelatorioVendaService(AppDbContext context) {
            _context = context;
        }

        //Metodo que ira receber a data inicial e final
        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) {
            //Retornar uma lista dos pedidos
            var resultado = from obj in _context.Pedidos select obj;
            if (minDate.HasValue) {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if (maxDate.HasValue) {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value); 
            }
            
            return await resultado.Include(l => l.PedidoItens).ThenInclude(l => l.Produto).OrderByDescending(x => x.PedidoEnviado).ToListAsync();
        }
    }
}
