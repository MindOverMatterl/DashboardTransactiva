using System.Threading.Tasks;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;

namespace TransActiva.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransactivaDbContext _context;

        public IUserRepository Users { get; }
        public IUserProfileRepository UserProfiles { get; }
        public IPedidoRepository Pedidos { get; }
        public IPedidoProductoRepository PedidoProductos { get; }
        public IPagoRepository Pagos { get; }
        public IBoletaRepository Boletas { get; }
        public IPreparacionRepository Preparaciones { get; }
        public IEnvioRepository Envios { get; }
        public IUserTypeRepository UserTypes { get; }
    
        public UnitOfWork(
            TransactivaDbContext context,
            IUserRepository users,
            IUserProfileRepository userProfiles,
            IPedidoRepository pedidos,
            IPedidoProductoRepository pedidoProductos,
            IPagoRepository pagos,
            IBoletaRepository boletas,
            IPreparacionRepository preparaciones,
            IEnvioRepository envios,
            IUserTypeRepository userTypes)
        
            
        
        {
            _context = context;
            Users = users;
            UserProfiles = userProfiles;
            Pedidos = pedidos;
            PedidoProductos = pedidoProductos;
            Pagos = pagos;
            Boletas = boletas;
            Preparaciones = preparaciones;
            Envios = envios;
            UserTypes = userTypes;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}