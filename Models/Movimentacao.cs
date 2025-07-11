using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _071125_Desafio_MVC.Models
{
    public class Movimentacao
    {
        [Key]
        public int MovimentacaoId { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        [StringLength(50)]
        public string NovoStatus { get; set; }

        [Required]
        [StringLength(100)]
        public string Responsavel { get; set; }
    }
}
