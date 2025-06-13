using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;
using DomainPreparacion = TransActiva.Domain.Entities.Preparacion;

namespace TransActiva.Infrastructure.Repositories
{
    public class PreparacionRepository(TransactivaDbContext context) : IPreparacionRepository
    {
        public async Task<IEnumerable<DomainPreparacion>> GetAllAsync()
        {
            var preparaciones = await context.Preparacions.ToListAsync();

            return preparaciones.Select(e => new DomainPreparacion
            {
                Id = e.IdPreparacion,
                Estado = e.Estado,
                ComoEnvia = e.ComoEnvia,
                Detalles = e.Detalles,
                IdEnvio = e.IdEnvio
            });
        }

        public async Task<DomainPreparacion?> GetByIdAsync(int id)
        {
            var e = await context.Preparacions.FindAsync(id);
            if (e == null) return null;

            return new DomainPreparacion
            {
                Id = e.IdPreparacion,
                Estado = e.Estado,
                ComoEnvia = e.ComoEnvia,
                Detalles = e.Detalles,
                IdEnvio = e.IdEnvio
            };
        }
    }
}