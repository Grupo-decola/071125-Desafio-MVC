using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _071125_Desafio_MVC.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(18)] // CPF: 11, CNPJ: 14, com pontuação
        public string? CpfCnpj { get; set; }

        [Required]
        [StringLength(200)]
        public string? Endereco { get; set; }

        [Required]
        [StringLength(20)]
        public string? Telefone { get; set; }

        // Navegação
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
