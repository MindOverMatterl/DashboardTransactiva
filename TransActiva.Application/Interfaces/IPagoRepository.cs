using System.Collections.Generic;
using System.Threading.Tasks;
using TransActiva.Domain.Entities;

namespace TransActiva.Application.Interfaces
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pago>> GetAllAsync();
        Task<Pago?> GetByIdAsync(int id);
    }
}