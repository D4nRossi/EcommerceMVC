using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceMVC.Models {
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem {

        [Key]
        public int CarrinhoCompraItemId { get; set; }
        //FK
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
