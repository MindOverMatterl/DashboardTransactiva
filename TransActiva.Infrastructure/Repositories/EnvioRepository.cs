using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;
using DomainEnvio = TransActiva.Domain.Entities.Envio;

namespace TransActiva.Infrastructure.Repositories
{
    public class EnvioRepository(TransactivaDbContext context) : IEnvioRepository
    {
        public async Task<IEnumerable<DomainEnvio>> GetAllAsync()
        {
            var envios = await context.Envios.ToListAsync();

            return envios.Select(e => new DomainEnvio
            {
                Id = e.IdEnvio,
                Estado = e.Estado,
                NombreEmpresa = e.NombreEmpresa,
                RucEmpresa = e.RucEmpresa,
                Asesor = e.Asesor,
                NumeroTelefonico = e.NumeroTelefonico,
                DireccionEnvio = e.DireccionEnvio,
                DireccionRecojo = e.DireccionRecojo,
                FechaLlegada = e.FechaLlegada,
                NroGuia = e.NroGuia
            });
        }

        public async Task<DomainEnvio?> GetByIdAsync(int id)
        {
            var e = await context.Envios.FindAsync(id);
            if (e == null) return null;

            return new DomainEnvio
            {
                Id = e.IdEnvio,
                Estado = e.Estado,
                NombreEmpresa = e.NombreEmpresa,
                RucEmpresa = e.RucEmpresa,
                Asesor = e.Asesor,
                NumeroTelefonico = e.NumeroTelefonico,
                DireccionEnvio = e.DireccionEnvio,
                DireccionRecojo = e.DireccionRecojo,
                FechaLlegada = e.FechaLlegada,
                NroGuia = e.NroGuia
            };
        }
    }
}