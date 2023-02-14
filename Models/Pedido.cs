using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceMVC.Models {
    [Table("Pedido")]
    public class Pedido {
        [Key]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Informe seu nome")]
        [StringLength(50)]
        [Display(Name ="Primeiro Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe seu sobrenome")]
        [StringLength(50)]
        [Display(Name = "Último Nome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe seu endereço")]
        [StringLength (100)]
        [Display(Name = "Endreço principal")]
        public string Endereco1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Complemento")]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Informe seu CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string CEP { get; set; }

        [StringLength (10)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [StringLength(50)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular - com código do país")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe seu e-mail")]
        [StringLength(60)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Formato Invalido")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total do Pedido")]
        public decimal PedidoTotal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Itens no Pedido")]
        public int TotalItensPedido { get; set; }

        public DateTime PedidoEnviado { get; set; }

        public DateTime? PedidoEntegue { get; set; }

        public List<PedidoDetalhe> PedidoItens { get; set; }
    }
}
