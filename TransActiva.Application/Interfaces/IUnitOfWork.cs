using System.Threading.Tasks;
using TransActiva.Domain.Entities;

namespace TransActiva.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserProfileRepository UserProfiles { get; }
        IPedidoRepository Pedidos { get; }
        IPedidoProductoRepository PedidoProductos { get; }
        IPagoRepository Pagos { get; }
        IBoletaRepository Boletas { get; }
        IPreparacionRepository Preparaciones { get; }
        IEnvioRepository Envios { get; }
        IUserTypeRepository UserTypes { get; }
    
        Task<int> CompleteAsync();
        Task SaveAsync(); // ← Esto es lo que falta
    }
}