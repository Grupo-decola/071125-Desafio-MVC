using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _071125_Desafio_MVC.Models;

namespace _071125_Desafio_MVC.Data
{
    public class _071125_Desafio_MVCContext : DbContext
    {
        public _071125_Desafio_MVCContext (DbContextOptions<_071125_Desafio_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<_071125_Desafio_MVC.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<_071125_Desafio_MVC.Models.Pedido> Pedido { get; set; } = default!;
    }
}
