using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;
using DomainBoleta = TransActiva.Domain.Entities.Boleta;

namespace TransActiva.Infrastructure.Repositories
{
    public class BoletaRepository(TransactivaDbContext context) : IBoletaRepository
    {
        public async Task<IEnumerable<DomainBoleta>> GetAllAsync()
        {
            var boletas = await context.Boleta.ToListAsync();

            return boletas.Select(e => new DomainBoleta
            {
                Id = e.IdBoleta,
                Ruta = e.Ruta
            });
        }

        public async Task<DomainBoleta?> GetByIdAsync(int id)
        {
            var e = await context.Boleta.FindAsync(id);
            if (e == null) return null;

            return new DomainBoleta
            {
                Id = e.IdBoleta,
                Ruta = e.Ruta
            };
        }
    }
}