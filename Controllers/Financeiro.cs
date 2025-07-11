using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _071125_Desafio_MVC.Controllers
{
    public class Financeiro : Controller
    {
        public readonly _071125_Desafio_MVC.Data._071125_Desafio_MVCContext _context;
        public Financeiro(_071125_Desafio_MVC.Data._071125_Desafio_MVCContext context)
        {
            _context = context;
        }
        public IActionResult RelatorioCliente(int id)
        {
          var cliente = _context.Cliente.Include(c => c.Pedidos).FirstOrDefault(c =>c.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            var pedidos = cliente.Pedidos.Select(p => new
            {
                p.PedidoId,
                p.DataPedido,
                p.EnderecoEntrega,
                p.Status,
                p.Valor
            }).ToList();
            var totalGasto = pedidos.Sum(p => p.Valor);
            ViewData  ["TotalGasto"] = totalGasto;
            return View(cliente);
        }
    }
}
