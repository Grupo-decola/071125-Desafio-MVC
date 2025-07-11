using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _071125_Desafio_MVC.Models
{

    public class Pedido
    {
        [Key]
        public int PedidoId  { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Required]
        public DateTime DataPedido { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [StringLength(200)]
        public string? EnderecoEntrega { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pendente";

        [DataType(DataType.Currency)]
        public decimal Valor { get; set; } = 0.0m;

        // Navegação
        public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
 



}
