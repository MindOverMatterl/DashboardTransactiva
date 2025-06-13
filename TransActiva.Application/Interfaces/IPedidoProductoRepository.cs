using System.Collections.Generic;
using System.Threading.Tasks;
using TransActiva.Domain.Entities;

namespace TransActiva.Application.Interfaces
{
    public interface IPedidoProductoRepository
    {
        Task<IEnumerable<PedidoProducto>> GetAllAsync();
        Task<PedidoProducto?> GetByIdAsync(int id);
    }
}