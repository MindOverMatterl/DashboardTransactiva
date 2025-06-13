using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;
using DomainPago = TransActiva.Domain.Entities.Pago;

namespace TransActiva.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly TransactivaDbContext _context;

        public PagoRepository(TransactivaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DomainPago>> GetAllAsync()
        {
            var pagos = await _context.Pagos.ToListAsync();

            return pagos.Select(p => new DomainPago
            {
                Id = p.IdPago,
                Monto = p.Monto ?? 0,
                FechaPago = p.FechaPago ?? DateTime.MinValue,
                Estado = p.Estado ?? string.Empty,
                Fecha = p.Fecha ?? DateTime.MinValue,
                IdBoleta = p.IdBoleta ?? 0
            });
        }

        public async Task<DomainPago?> GetByIdAsync(int id)
        {
            var p = await _context.Pagos.FindAsync(id);
            if (p == null) return null;

            return new DomainPago
            {
                Id = p.IdPago,
                Monto = p.Monto ?? 0,
                FechaPago = p.FechaPago ?? DateTime.MinValue,
                Estado = p.Estado ?? string.Empty,
                Fecha = p.Fecha ?? DateTime.MinValue,
                IdBoleta = p.IdBoleta ?? 0
            };
        }

        // Eliminar este método, ya que PedidoId no existe
        // public async Task<IEnumerable<DomainPago>> GetByPedidoIdAsync(int pedidoId) { ... }
    }
}