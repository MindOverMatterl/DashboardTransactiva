using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;
using DomainPedidoProducto = TransActiva.Domain.Entities.PedidoProducto;

namespace TransActiva.Infrastructure.Repositories
{
    public class PedidoProductoRepository(TransactivaDbContext context) : IPedidoProductoRepository
    {
        public async Task<IEnumerable<DomainPedidoProducto>> GetAllAsync()
        {
            var productos = await context.Pedidosproductos.ToListAsync();

            return productos.Select(e => new DomainPedidoProducto
            {
                Id = e.IdPedidosProductos,
                Producto = e.Producto,
                Cantidad = e.Cantidad,
                Descripcion = e.Descripcion,
                DireccionEntrega = e.DireccionEntrega,
                FechaLlegadaAcordada = e.FechaLlegadaAcordada,
                FechaSolicitada = e.FechaSolicitada,
                NombreTransaccion = e.NombreTransaccion,
                IdPago = e.IdPago,
                IdPreparacion = e.IdPreparacion
            });
        }

        public async Task<DomainPedidoProducto?> GetByIdAsync(int id)
        {
            var e = await context.Pedidosproductos.FindAsync(id);
            if (e == null) return null;

            return new DomainPedidoProducto
            {
                Id = e.IdPedidosProductos,
                Producto = e.Producto,
                Cantidad = e.Cantidad,
                Descripcion = e.Descripcion,
                DireccionEntrega = e.DireccionEntrega,
                FechaLlegadaAcordada = e.FechaLlegadaAcordada,
                FechaSolicitada = e.FechaSolicitada,
                NombreTransaccion = e.NombreTransaccion,
                IdPago = e.IdPago,
                IdPreparacion = e.IdPreparacion
            };
        }
    }
}