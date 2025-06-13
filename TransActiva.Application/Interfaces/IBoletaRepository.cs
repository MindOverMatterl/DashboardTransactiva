using System.Collections.Generic;
using System.Threading.Tasks;
using TransActiva.Domain.Entities;

namespace TransActiva.Application.Interfaces
{
    public interface IBoletaRepository
    {
        Task<IEnumerable<Boleta>> GetAllAsync();
        Task<Boleta?> GetByIdAsync(int id);
    }
}