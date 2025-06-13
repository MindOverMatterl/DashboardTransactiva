using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;
using DomainPedido = TransActiva.Domain.Entities.Pedido;
using DbPedido = TransActiva.Infrastructure.Persistence.Entities.Pedido;

namespace TransActiva.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly TransactivaDbContext _context;

        public PedidoRepository(TransactivaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DomainPedido>> GetAllAsync()
        {
            var pedidos = await _context.Pedidos.ToListAsync();

            return pedidos.Select(e => new DomainPedido
            {
                Id = e.IdPedido,
                IdProveedor = e.IdProveedor ?? 0,
                IdComprador = e.IdComprador ?? 0,
                IdPedidosProductos = e.IdPedidosProductos ?? 0,
                Estado = e.Estado ?? string.Empty
            });
        }

        public async Task<DomainPedido?> GetByIdAsync(int id)
        {
            var e = await _context.Pedidos.FindAsync(id);
            if (e == null) return null;

            return new DomainPedido
            {
                Id = e.IdPedido,
                IdProveedor = e.IdProveedor ?? 0,
                IdComprador = e.IdComprador ?? 0,
                IdPedidosProductos = e.IdPedidosProductos ?? 0,
                Estado = e.Estado ?? string.Empty
            };
        }

        public async Task<IEnumerable<DomainPedido>> GetByUserIdAsync(int userId)
        {
            var pedidos = await _context.Pedidos
                .Where(p => p.IdComprador == userId)
                .ToListAsync();

            return pedidos.Select(e => new DomainPedido
            {
                Id = e.IdPedido,
                IdProveedor = e.IdProveedor ?? 0,
                IdComprador = e.IdComprador ?? 0,
                IdPedidosProductos = e.IdPedidosProductos ?? 0,
                Estado = e.Estado ?? string.Empty
            });
        }
    }
}
