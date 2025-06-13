using System.Collections.Generic;
using System.Threading.Tasks;
using TransActiva.Domain.Entities;

namespace TransActiva.Application.Interfaces
{
    public interface IEnvioRepository
    {
        Task<IEnumerable<Envio>> GetAllAsync();
        Task<Envio?> GetByIdAsync(int id);
    }
}